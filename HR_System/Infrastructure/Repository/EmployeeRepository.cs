using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using Microsoft.EntityFrameworkCore;
using NLog.LayoutRenderers;

namespace HR_System.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        

        public async Task<bool> DeleteAsync(long id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                
            }
            return await _dbContext.SaveChangesAsync() > 0;

        }
        public  async Task<IEnumerable<Employee>> GetAllAsync()
        {          
            return await _dbContext.Employees.ToListAsync();
        }

        public Task<Employee> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public  async Task<Employee> GetByIdAsync(long id)
        {
            return await _DbSet.FirstOrDefaultAsync(e => e.Id == id)
                   ?? throw new InvalidOperationException($"Employee with ID {id} not found.");
        }

        public  async Task<bool> UpdateAsync(Employee entity)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == entity.Id);
            
            if (employee == null)
                throw  new InvalidOperationException($"Employee with ID {entity.Id} not found.");

            employee = entity;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
