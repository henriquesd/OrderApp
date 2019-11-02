using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using System.Threading.Tasks;

namespace OrderApp.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Add(Order order)
        {
            await _orderRepository.Add(order);
            return true;
        }

        public void Dispose()
        {
            _orderRepository?.Dispose();
        }
    }
}
