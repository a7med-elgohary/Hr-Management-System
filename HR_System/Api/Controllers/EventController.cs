using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repo;

        public EventController(IEventRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] eventRequest events)
        {
            // Map eventRequest to Events  
            var eventEntity = new Events
            {
                Id = events.Id,
                Name = events.Name,
                Description = events.Description,
                CreatedDate = events.CreatedDate,
                EmployeeID = events.EmployeeID,
                IsDeleted = false,

            };

            try{
                await _repo.AddAsync(eventEntity);
            }
            catch(Exception ex)
            {
                var massge = ex.Message;
                return StatusCode(500, new
                {
                    Error = "AN EXPTION OCCURRD",
                    massge = ex.Message,
                    StackTrace = ex.StackTrace
                }
                    
                    
                 );
            }
            return Ok(eventEntity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(Events events)
        {
            await _repo.UpdateAsync(events); // UpdateAsync returns void, so no assignment is needed
            return Ok(events); // Return the updated event object
        }

        [HttpGet("IsAvailableEvents")]
        public async Task<IActionResult> IsAvailableEvents()
        {
            var evnts = await _repo.GetIsAvailableEvents();
            return evnts != null ? Ok(evnts) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var evnt = await _repo.GetByIdAsync(id);
            return evnt != null ? Ok(evnt) : NotFound();
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var evnt = await _repo.GetAllAsync();
            return evnt != null ? Ok(evnt) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok("delet sucsess");
        }
    }

    public class eventRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public long EmployeeID { get; set; }
    }
}

