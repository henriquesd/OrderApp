using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderApp.API.Controllers;
using OrderApp.API.Dtos;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.API.Tests
{
    public class CustomersControllerTest
    {
        private readonly CustomersController _customersController;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Faker _faker;

        public CustomersControllerTest()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerServiceMock = new Mock<ICustomerService>();
            _mapperMock = new Mock<IMapper>();
            _customersController = new CustomersController(_customerRepositoryMock.Object, _customerServiceMock.Object, _mapperMock.Object);
            _faker = new Faker();
        }

        [Fact]
        public async void GetCustomerOrders_ShouldReturn_CustomerOrders()
        {
            var customerOrders = CreateCustomerOrders();
            var dtoExpected = MapModelToCustomerOrdersDto(customerOrders);

            _customerRepositoryMock.Setup(c => c.GetCustomersOrders(customerOrders.Id)).ReturnsAsync(customerOrders);
            _mapperMock.Setup(m => m.Map<CustomerOrdersDto>(It.IsAny<Customer>())).Returns(dtoExpected);

            var result = await _customersController.GetCustomersOrders(customerOrders.Id);

            Assert.Equal(dtoExpected, result.Value);
        }

        [Fact]
        public async void GetAll_ShouldReturn_ListOfCustomers()
        {
            var customers = CreateCustomers();
            var dtoExpected = MapListCustomerToDto(customers);

            _customerRepositoryMock.Setup(c => c.GetAll()).ReturnsAsync(customers);
            _mapperMock.Setup(mock => mock.Map<CustomerDto[]>(It.IsAny<List<Customer>>())).Returns(dtoExpected.ToArray());
            var result = await _customersController.GetAll();

            Assert.Equal(dtoExpected, result);
        }

        [Fact]
        public async void ShouldCreateCustomer()
        {
            var customer = CreateCustomer();
            var customerDto = MapCustomerToDto(customer);

            _customerRepositoryMock.Setup(o => o.Add(customer)).Returns(Task.FromResult(true));
            _customerServiceMock.Setup(o => o.Add(customer)).Returns(Task.FromResult(true));
            _mapperMock.Setup(m => m.Map<Customer>(It.IsAny<CustomerDto>())).Returns(customer);

            var result = await _customersController.Add(customerDto);

            Assert.IsType<ActionResult<CustomerDto>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private Customer CreateCustomer()
        {
            return new Customer { Name = _faker.Person.FullName, Email = _faker.Person.Email };
        }

        private List<Customer> CreateCustomers()
        {
            return new List<Customer>() { new Customer { Name = _faker.Person.FullName, Email = _faker.Person.Email } };
        }
        
        private Customer CreateCustomerOrders()
        {
            var customerId = _faker.Random.Guid();

            return new Customer()
            {
                Id = customerId,
                Name = _faker.Person.FullName,
                Email = _faker.Person.Email,
                Orders = new List<Order>()
                    {
                        new Order
                        {
                            CustomerId = customerId,
                            Price = 10
                        }
                    }
            };
        }

        private CustomerDto MapCustomerToDto(Customer customer)
        {
            return new CustomerDto { Name = customer.Name, Email = customer.Email };
        }

        private List<CustomerDto> MapListCustomerToDto(List<Customer> customers)
        {
            return customers.Select(c => new CustomerDto { Id = c.Id, Name = c.Name, Email = c.Email }).ToList();
        }

        private CustomerOrdersDto MapModelToCustomerOrdersDto(Customer customer)
        {
            return new CustomerOrdersDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Orders = new List<OrderDto>()
                {
                    new OrderDto
                    {
                        CustomerId = customer.Id,
                        Price = 10
                    }
                }
            };
        }
    }
}
