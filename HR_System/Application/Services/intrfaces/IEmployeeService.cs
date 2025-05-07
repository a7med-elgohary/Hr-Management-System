using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;

namespace HR_System.Application.Services.intrfaces
{
    public interface IEmployeeService : IGenericRepository<Employee>
    {

    }
}
