using Microsoft.EntityFrameworkCore;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderApp.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderAppDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetCustomersOrders(Guid id)
        {
            return await Db.Customers.AsNoTracking()
               .Include(c => c.Orders)
               .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}