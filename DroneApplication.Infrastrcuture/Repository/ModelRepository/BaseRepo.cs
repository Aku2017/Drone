using DroneApplication.Domain.Interfaces;
using DroneApplication.Infrastructure.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Infrastructure.Repository.ModelRepository
{
  public class BaseRepo<T> : IBaseRepo<T> where T: class
    {
        protected readonly DroneDbContext droneDbContext;

        public BaseRepo(DroneDbContext _droneDbContext)
        {
            this.droneDbContext = _droneDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await droneDbContext.Set<T>().AddAsync(entity);
            await droneDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            droneDbContext.Set<T>().Remove(entity);
            await droneDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await droneDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
           return await droneDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            droneDbContext.Set<T>().Update(entity);
            await droneDbContext.SaveChangesAsync();
           
           // throw new NotImplementedException();
        }
    }
}
