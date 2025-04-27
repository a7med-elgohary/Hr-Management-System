using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_System.Domain.Models
{
    public class EmployeeTask
    {
        [Key]
        public long Id { get; set; } 

        [Required]
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }  

        [Required]
        [StringLength(200)] 
        public required string TaskDescription { get; set; } 

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        public DateTime EndDate { get; set; } 

        [Required]
        public TaskStatus Status { get; set; } 

        //many to one
        public required virtual Employee Employee { get; set; } 
    }
}
