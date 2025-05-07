using HR_System.Application.Services.intrfaces;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository;
using HR_System.Infrastructure.Repository.Intefaces;

namespace HR_System.Application.Services
{
    public class EmployeeService : IEmployeeService
    {

        private IEmployeeRepository _employeeRepository;  

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
