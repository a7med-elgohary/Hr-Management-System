using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class Events
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Employee")]
        public long EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }

}
