using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddEvent(Events events)
        {
            var evnts = _repo.AddAsync(events);
            return Ok(evnts);
        }

        [HttpPut]
        public IActionResult UpdateEvent(Events events)
        {
            var evnt = _repo.UpdateAsync(events);
            return evnt != null ? Ok(evnt) : NotFound();
        }

        [HttpGet("IsAvailableEvents")]
        public IActionResult IsAvailableEvents()
        {
            var evnts = _repo.GetIsAvailableEvents();
            return evnts != null ? Ok(evnts) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var evnt = _repo.GetByIdAsync(id);
            return evnt != null ? Ok(evnt) : NotFound();
        }

        [HttpGet("GetAllEvents")]
        public IActionResult GetAllEvents()
        {
            var evnt = _repo.GetAllAsync();
            return evnt != null ? Ok(evnt) : NotFound();
        }

        [HttpDelete]
        public IActionResult AddEvent(int id)
        {
            var evnts = _repo.DeleteAsync(id);
            return evnts != null ? Ok(evnts) : NotFound();
        }
    }
}
