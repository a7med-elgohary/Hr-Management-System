using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;
using HR_System.RequestClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNew([FromBody] Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            return Ok(employee);
        }

        public class EmployyRequset
        {
            [Required]
            public required string FullName { get; set; }
            // Email - UNIQUE and NOT NULL
            [Required]
            [EmailAddress]
            public required string Email { get; set; }
            // Address - NULLABULE
            [StringLength(200)]
            public string? Address { get; set; }
            // Phone Number - NOT NULL
            [Required]
            public required string PhoneNumber { get; set; }
            // Phone Number - NOT NULL
            [Required]
            public required string JobTitle { get; set; }
            // Hire Date - NOT NULL
            [Required]
            public required DateTime HireDate { get; set; } = DateTime.Now;
            // Salary - NOT NULL and range check
            [Required]
            [Range(0, double.MaxValue)]
            public decimal NetSalary { get; set; }
            //50,000
            //relation ships
            //Many Employee to One Dept
            [ForeignKey("Department")]
            public long DepartmentId { get; set; }
            [Required]
            public required Department Department { get; set; }

            //user account
            [ForeignKey("UserAccount")]
            public long? UserAccountId { get; set; }
            [Required]
            public required User? UserAccount { get; set; }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest("ID mismatch");

            var success = await _employeeRepository.UpdateAsync(employee);

            if (!success) return NotFound("Employee not found or update failed"); // Handle failure properly

            return NoContent(); // Success, return HTTP 204
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromForm] EmployeeDto employeeDto)
        {
            if (employeeDto.Photo == null || employeeDto.Photo.Length == 0)
                return BadRequest("Photo is required.");

            // Save the photo
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeDto.Photo.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await employeeDto.Photo.CopyToAsync(stream);
            }

            // Create the employee
            var employee = new Employee
            {
                FullName = employeeDto.FullName,
                Email = employeeDto.Email,
                Address = employeeDto.Address,
                PhoneNumber = employeeDto.PhoneNumber,
                JobTitle = employeeDto.JobTitle,
                HireDate = employeeDto.HireDate,
                NetSalary = employeeDto.NetSalary,
                DepartmentId = employeeDto.DepartmentId,
                ur = $"/uploads/{fileName}" // Relative path to access later
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _employeeRepository.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }



    }
}
