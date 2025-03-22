using HR_System.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class Salary
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Range(0,double.MaxValue)]
        public decimal? Bounes { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Deduction { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Ammout { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public SalaryStatus Status { get; set; }

        public required virtual  Employee Employee { get; set; }
    }
}