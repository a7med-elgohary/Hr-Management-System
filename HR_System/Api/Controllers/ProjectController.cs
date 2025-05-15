using AutoMapper;
using HR_System.Application.intrfaces;
using HR_System.Domain.Models;
using HR_System.RequestClasses;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        private IMapper _mapper;
        public ProjectController(IProjectService projectService , IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper; 
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll() => Ok(await _projectService.GetAllAsync() ?? throw new ArgumentNullException(nameof(_projectService)));
        

        [HttpPost("")]
        public async Task<IActionResult> AddNew([FromBody] ProjectDto projectDto)
        {

            var project = _mapper.Map<Project>(projectDto);
            await _projectService.AddAsync(project);

            return Ok("Project added successfully");
        }









    }
}
