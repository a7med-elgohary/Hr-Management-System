using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;

namespace HR_System.Application.intrfaces
{
    public interface IEmployeeService : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetFirst(int number);

    }
}
