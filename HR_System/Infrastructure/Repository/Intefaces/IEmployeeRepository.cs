using HR_System.Domain.Models;

namespace HR_System.Infrastructure.Repository.Intefaces
{
    public interface IEmployeeRepository 
    {
        public Task<bool> AddAsync(Employee employee);
        public Task<bool> DeleteAsync(long id);
        public Task<IEnumerable<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(Employee entity);
        public Task<Employee> GetByEmailAsync(string email);


    }
}
