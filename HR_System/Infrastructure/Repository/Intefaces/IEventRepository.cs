using HR_System.Domain.Models;

namespace HR_System.Infrastructure.Repository.Intefaces
{
    public interface IEventRepository : IGenericRepository<Events>
    {
        Task<IEnumerable<Events>> GetIsAvailableEvents();
    }
}
