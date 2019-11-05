using Bogus;
using Moq;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.Domain.Tests
{
    public class OrderServiceTest
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private OrderService _orderService;
        private readonly Faker _faker;

        public OrderServiceTest()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object);
            _faker = new Faker();
        }

        [Fact]
        public async void ShouldCreateMultipleOrders_ForTheSameCustomer()
        {
            var order = new Order
            {
                CustomerId = _faker.Random.Guid(),
                Price = _faker.Random.Decimal()
            };

            _orderRepositoryMock.Setup(o => o.Add(order)).Returns(Task.FromResult(true));

            var result = await _orderService.Add(order);
            result = await _orderService.Add(order);

            Assert.True(result);
        }
    }
}
