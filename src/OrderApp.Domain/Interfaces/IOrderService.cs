using OrderApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderApp.Domain.Interfaces
{
    public interface IOrderService : IDisposable
    {
        Task<bool> Add(Order order);
    }
}
