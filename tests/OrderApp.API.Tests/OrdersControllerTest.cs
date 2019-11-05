using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderApp.API.Controllers;
using OrderApp.API.Dtos;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.API.Tests
{
    public class OrdersControllerTest
    {
        private readonly OrdersController _orderController;
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Faker _faker;

        public OrdersControllerTest()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _mapperMock = new Mock<IMapper>();
            _orderController = new OrdersController(_orderServiceMock.Object, _mapperMock.Object);
            _faker = new Faker();
        }

        [Fact]
        public async void ShouldCreateOrder()
        {
            var order = CreateOrder();
            var orderDto = MapModelToDto(order);

            _orderServiceMock.Setup(o => o.Add(order)).Returns(Task.FromResult(true));
            _mapperMock.Setup(m => m.Map<Order>(It.IsAny<OrderDto>())).Returns(order);

            var result = await _orderController.Add(orderDto);

            Assert.IsType<ActionResult<OrderDto>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private Order CreateOrder()
        {
            return new Order { Price = _faker.Random.Decimal(), CustomerId = _faker.Random.Guid() };
        }

        private OrderDto MapModelToDto(Order order)
        {
            return new OrderDto() { Price = order.Price, CustomerId = order.CustomerId };
        }
    }
}
