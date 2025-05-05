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
            if (events.Id == 0 && events.EmployeeID == 0)
            {
                throw new ValidationException("ID and Employee ID Are Required");
            }
            else if (events.CreatedDate < DateTime.Now)
            {
                throw new ValidationException("The Date must be in the future");
            }
            await _dbContext.events.AddAsync(events);
            await _dbContext.SaveChangesAsync();
        }
    }
}
