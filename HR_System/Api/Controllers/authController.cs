using HR_System.Application.intrfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_System.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class authController : ControllerBase
    {
        private readonly IAuthService _authService;
        public authController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Username, request.Password);
            if (token == null)
                return Unauthorized(new { message = "Invalid username or password" });
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.Success)
                return BadRequest(new { message = result.ErrorMessage });
            return Ok(new { message = "Registration successful"});
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Test successful" });
        }

        public class LoginRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }

        public class RegisterRequest
        {
            public required string Username { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
            public long EmployeeId { get; set; }
        }
    }
}
