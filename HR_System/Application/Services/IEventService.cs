using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;

namespace HR_System.Application.Services
{
    public interface IEventService : IGenericRepository<Events>
    {
        Task<IEnumerable<Events>> GetFirst(int number);

    }
}
