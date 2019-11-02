using Microsoft.EntityFrameworkCore;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace OrderApp.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderAppDbContext context) : base(context) { }

        public async Task<Customer> GetCustomersOrders(Guid id)
        {
            return await Db.Customers.AsNoTracking()
               .Include(c => c.Orders)
               .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}