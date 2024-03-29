﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Domain.Interfaces
{
  public interface IBaseRepo<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
       
    }
}
