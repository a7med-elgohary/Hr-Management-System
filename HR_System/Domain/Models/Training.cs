using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HR_System.Domain.Models.Enums;

namespace HR_System.Domain.Models
{
    public class Training
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public required string TrainingName { get; set; }

        [Required]
        public DateTime TrainingDate { get; set; }

        [Required]
        public TrainingStatus Status { get; set; }


        public required virtual Employee Employee { get; set; }
    }
}