using Microsoft.EntityFrameworkCore;
using OrderApp.Domain.Interfaces;
using OrderApp.Domain.Models;
using OrderApp.Infrastructure.Context;
using System.Threading.Tasks;

namespace OrderApp.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly OrderAppDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(OrderAppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
