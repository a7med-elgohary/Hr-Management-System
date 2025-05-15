using HR_System.Application.intrfaces;
using HR_System.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DashBoardController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IProjectService _projectService;
        private readonly IEventService _eventService;
        public DashBoardController(IProjectService projectService ,IEmployeeService employeeService , IEventService eventService)
        {
            _eventService = eventService;
            _projectService = projectService;
            _employeeService = employeeService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetFirst(8);
            var projects = await _projectService.GetFirst(5);
            var Events = await _eventService.GetFirst(5);
            return Ok(new
            {
                Employees = employees,
                Projects = projects,
                Events = Events
            });
        }





    }
}
