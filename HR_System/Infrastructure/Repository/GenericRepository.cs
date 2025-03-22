using HR_System.Infrastructure.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HR_System.Infrastructure.Repository
{
    public class GenericRepository <T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _Dbset;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _Dbset = _dbContext.Set<T>();  
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
