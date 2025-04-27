using HR_System.Infrastructure.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HR_System.Infrastructure.Repository
{
    public abstract class GenericRepository <T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _Dbset;

        protected GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _Dbset = _dbContext.Set<T>();  
        }

        public abstract Task AddAsync(T entity);
        public abstract Task DeleteAsync(long id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(long id);
        public abstract Task UpdateAsync(T entity);
    }
}
