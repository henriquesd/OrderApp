using OrderApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderApp.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomersOrders(Guid id);
    }
}