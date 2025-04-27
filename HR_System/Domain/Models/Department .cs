using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public required string Name { get; set; }


        // Relation ships
        public ICollection<Employee>? Employees { get; set; }
        [ForeignKey("Manager")]
        public long? ManagerId { get; set; }
        public Employee? Manager { get; set; }
    }
}
