using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HR_System.Domain.Models
{
    public class Promotion //ترقيه
    {
        [Key]
        public long Id { get; set; }

        // Foreign key to Employee table
        [ForeignKey("Employee")]
        public long employeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public DateTime PromotionDate { get; set; } = DateTime.Now;

        [Required]
        public required string NewJobTitle { get; set; } 

        [Required]
        [Range(0,double.MaxValue)]
        public decimal NewSalary { get; set; }

        [Required]
        public required string Reason { get; set; }
    }
}


#region Relations
//شرح الجداول والعلاقات:
//الجدول promotions يحتوي على:

//id: هو المفتاح الأساسي ويستخدم للتعرف على السجل.

//employee_id: هو المفتاح الخارجي الذي يرتبط بموظف في جدول employees، أي أن كل ترقية تخص موظفًا واحدًا.

//promotion_date: تاريخ الترقية.

//new_job_title: المسمى الوظيفي الجديد بعد الترقية.

//new_salary: الراتب الجديد بعد الترقية.

//reason: سبب الترقية.

//العلاقة بين Promotion و Employee:

//علاقة Many-to-One بين Promotion و Employee: حيث يمكن لكل موظف الحصول على العديد من الترقيات.
#endregion