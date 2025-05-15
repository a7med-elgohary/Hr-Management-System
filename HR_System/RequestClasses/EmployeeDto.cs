using HR_System.Domain.Models;

namespace HR_System.RequestClasses
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }
        // Email - UNIQUE and NOT NULL
        public string Email { get; set; }
        // Address - NULLABULE
        public string? Address { get; set; }
        // Phone Number - NOT NULL
        public string? PhoneNumber { get; set; }

        public required string JobTitle { get; set; }
        public IFormFile? file { get; set; }
        public decimal NetSalary { get; set; }
        public string? Url { get; set; }
        public long DepartmentId { get; set; }
        public long? UserAccountId { get; set; } = null;
    }
}
