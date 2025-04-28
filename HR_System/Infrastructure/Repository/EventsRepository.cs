using HR_System.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR_System.Infrastructure.Repository
{
    public class EventsRepository : GenericRepository<Events>
    {
        public EventsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task AddAsync(Events events)
        {
            if (events.Id == null && events.EmployeeID == null)
            {
                throw new ValidationException("ID and Employee ID Are Required");
            }
            else if (events.CreatedDate < DateTime.Now)
            {
                throw new ValidationException("The Date must be in the future");
            }
            _dbContext.events.Add(events);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            _dbContext.events.Remove(evnt);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Events>> GetAllAsync()
        {
            var evnts = await _dbContext.events.ToListAsync();
            if (evnts == null)
            {
                throw new ValidationException("Not found");
            }
            return evnts;
        }

        public override async Task<Events> GetByIdAsync(long id)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            return evnt;
        }

        public override async Task UpdateAsync(Events _evnt)
        {
            var evnt = await _dbContext.events.FirstOrDefaultAsync(e => e.Id == _evnt.Id);
            if (evnt == null)
            {
                throw new ValidationException("Not found");
            }
            evnt = _evnt;
            await _dbContext.SaveChangesAsync();
        }
    }
}
