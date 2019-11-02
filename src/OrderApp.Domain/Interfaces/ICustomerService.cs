using OrderApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderApp.Domain.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task<bool> Add(Customer customer);
    }
}
