using Bogus;
using Moq;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.Domain.Tests
{
    public class CustomerServiceTest
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly CustomerService _customerService;
        private readonly string _name;
        private readonly string _email;

        public CustomerServiceTest()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
            var faker = new Faker();

            _name = faker.Person.FullName;
            _email = faker.Person.Email;
        }

        [Fact]
        public async void ShouldCreateCustomer_IfNameAndEmailIsValid()
        {
            var customer = CreateCustomer(_name, _email);

            _customerRepositoryMock.Setup(c => c.Add(customer)).Returns(Task.FromResult(true));

            var result = await _customerService.Add(customer);

            Assert.True(result);
        }

        [Theory]
        [InlineData(null, "aaa@aaa.com")]
        [InlineData("aaa", null)]
        [InlineData(null, null)]
        public async void ShouldNotCreateCustomer_IfNameOrEmailIsInvalid(string name, string email)
        {
            var customer = CreateCustomer(name, email);

            _customerRepositoryMock.Setup(c => c.Add(customer)).Returns(Task.FromResult(false));

            var result = await _customerService.Add(customer);

            Assert.False(result);
        }

        [Fact]
        public async void ShouldNotCreateCustomer_IfEmailAlreadyExists()
        {
            var customer = CreateCustomer(_name, _email);
            var customerList = CreateCustomerList(customer);

            _customerRepositoryMock.Setup(x => x.Search(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(customerList);

            var result = await _customerService.Add(customer);

            Assert.False(result);
        }

        private List<Customer> CreateCustomerList(Customer customer)
        {
            return new List<Customer>() { new Customer { Id = customer.Id, Name = customer.Name, Email = customer.Email } };
        }

        private Customer CreateCustomer(string name, string email)
        {
            return new Customer { Name = name, Email = email };
        }
    }
}

