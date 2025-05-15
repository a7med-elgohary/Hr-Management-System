using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;

namespace HR_System.Application.intrfaces
{
    public interface IProjectService 
    {
        Task<IEnumerable<Project>> GetFirst(int number);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(long id);
        Task AddAsync(Project entity);
        Task UpdateAsync(Project entity);
        Task DeleteAsync(long id);
    }
}
