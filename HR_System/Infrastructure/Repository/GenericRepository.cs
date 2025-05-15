using HR_System.Infrastructure.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_System.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _DbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = _dbContext.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _DbSet.FindAsync(id);
            if (entity != null)
            {
                _DbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _DbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
