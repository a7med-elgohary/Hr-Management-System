using HR_System.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

      

    }
}
