using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;

namespace HR_System.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }







    }
}
