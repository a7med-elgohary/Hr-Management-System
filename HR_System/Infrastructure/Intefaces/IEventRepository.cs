using HR_System.Domain.Models;

namespace HR_System.Infrastructure.Intefaces
{
    public interface IEventRepository : IGenericRepository<Events>
    {
        public Task<IEnumerable<Events>> GetIsAvailableEvents();
    }

}
