using HR_System.Application.intrfaces;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using HR_System.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HR_System.Application.Services
{
    public class ProjectServices : IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetFirst(int number)
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Take(number);
        }

        public async Task AddAsync(Project entity)
        {
            await _projectRepository.AddAsync(entity);
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            return _projectRepository.GetAllAsync();
        }

        public Task<Project> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
