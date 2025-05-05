using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR_System.Infrastructure.Repository
{
    public class EventsRepository : GenericRepository<Events> , IEventRepository
    {
        public EventsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(Events events)
        {
            if (events.Id == 0 && events.EmployeeID == 0)
            {
                throw new ValidationException("ID and Employee ID Are Required");
            }
            else if (events.CreatedDate < DateTime.Now)
            {
                throw new ValidationException("The Date must be in the future");
            }
<<<<<<< HEAD
            await _dbContext.events.AddAsync(events);
=======
            _dbContext.events.Add(events);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            _dbContext.events.Remove(evnt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Events>> GetAllAsync()
        {
            var evnts = await _dbContext.events.ToListAsync();
            if (evnts == null)
            {
                throw new ValidationException("Not found");
            }
            return evnts;
        }

        public async Task<Events> GetByIdAsync(long id)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            return evnt;
        }

        public async Task<IEnumerable<Events>> GetIsAvailableEvents()
        {
            var events = await _dbContext.events.Where(e => e.IsDeleted != false && e.CreatedDate.Day < DateTime.Now.Day).ToListAsync();
            if (events == null)
            {
                throw new ValidationException("No Events is available");
            }
            return events;
        }

        public async Task UpdateAsync(Events _evnt)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == _evnt.Id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            evnt = _evnt;
>>>>>>> e13e07eafbbe6b31b50e74b75e3954837246ba7a
            await _dbContext.SaveChangesAsync();
        }
    }
}
