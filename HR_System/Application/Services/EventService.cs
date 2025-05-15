using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;

namespace HR_System.Application.Services
{
    public class EventService : IEventService
    {

        private IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository; 
        }


        public Task AddAsync(Events entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Events>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Events> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Events>> GetFirst(int number)
        {
            var Events = await _eventRepository.GetAllAsync();
            return Events.ToList().Take(number);
        }

        public Task UpdateAsync(Events entity)
        {
            throw new NotImplementedException();
        }
    }
}
