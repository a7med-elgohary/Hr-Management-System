using HR_System.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NLog.LayoutRenderers;

namespace HR_System.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public override async Task AddAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }

        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {          
            return await _dbContext.Employees.ToListAsync();
        }

        public override async Task<Employee> GetByIdAsync(long id)
        {
            // هنا ممكن تعدل وتشيل الأكسبشن ده بس خلي النوع متاع المتغير الراجع nullable
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id)
                   ?? throw new InvalidOperationException($"Employee with ID {id} not found.");
        }

        public override async Task UpdateAsync(Employee entity)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == entity.Id);
            
            if (employee != null)
                throw  new InvalidOperationException($"Employee with ID {entity.Id} not found.");

            employee = entity;
            await _dbContext.SaveChangesAsync();
        }
    }
}
