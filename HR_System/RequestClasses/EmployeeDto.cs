namespace HR_System.RequestClasses
{
    public class EmployeeDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string JobTitle { get; set; }
        public required DateTime HireDate { get; set; } = DateTime.Now;
        public required decimal NetSalary { get; set; }
        public required long DepartmentId { get; set; }
        public IFormFile Photo { get; set; } // Accepts file from form
    }
}
