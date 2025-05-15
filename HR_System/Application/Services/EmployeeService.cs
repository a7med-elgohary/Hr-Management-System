using HR_System.Application.intrfaces;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using HR_System.Infrastructure.Repository;

namespace HR_System.Application.Services
{
    public class EmployeeService : IEmployeeService
    {

        private IEmployeeRepository _employeeRepository;  

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetFirst(int number)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Take(number);
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
