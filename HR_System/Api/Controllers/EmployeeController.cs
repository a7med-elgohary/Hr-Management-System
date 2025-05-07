using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;
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



    }
}
