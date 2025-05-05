using HR_System.Domain.Models;

namespace HR_System.Infrastructure.Repository.Intefaces
{
    public interface IEventRepository : IGenericRepository<Events>
    {
<<<<<<< HEAD
        
    }
    
}

=======
        Task<IEnumerable<Events>> GetIsAvailableEvents();
    }
}
>>>>>>> e13e07eafbbe6b31b50e74b75e3954837246ba7a
