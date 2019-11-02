using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Infrastructure.Context;

namespace OrderApp.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderAppDbContext context) : base(context) { }
    }
}
