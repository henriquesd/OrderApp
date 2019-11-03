using OrderApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderApp.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<int> SaveChanges();
    }
}
