using OrderApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderApp.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAll();
        Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        Task<Customer> GetCustomersOrders(Guid id);
    }
}