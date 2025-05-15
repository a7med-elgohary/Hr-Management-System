using HR_System.Domain.Models.Enums;
using HR_System.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_System.RequestClasses
{
    public class ProjectDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } = null;

        
        public Status Status { get; set; } = Status.Pending;  

        public virtual long? ManagerId { get; set; }


        // Additional fields for budget and description
        public decimal Budget { get; set; } = 0;  // Default value

        public string? Description { get; set; }

    }
}
