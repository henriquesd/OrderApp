using Bogus;
using Moq;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.Domain.Tests
{
    public class OrderServiceTest
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private OrderService _orderService;
        private readonly decimal _price;
        private readonly Guid _customerId;

        public OrderServiceTest()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepository.Object);
            var faker = new Faker();

            _price = faker.Random.Decimal();
            _customerId = faker.Random.Guid();
        }

        [Fact]
        public async void ShouldCreateMultipleOrders_ForTheSameCustomer()
        {
            var order = new Order
            {
                CustomerId = _customerId,
                Price = _price
            };

            _orderRepository.Setup(o => o.Add(order)).Returns(Task.FromResult(true));

            var result = await _orderService.Add(order);
            result = await _orderService.Add(order);

            Assert.True(result);
        }
    }
}
