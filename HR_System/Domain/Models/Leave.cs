using HR_System.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class Leave //اذن اجازه الخ 
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        public required string LeaveType { get; set; } // sick ect

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public LeaveStatus Status { get; set; }

        [Required]
        public required string Reason { get; set; }

        //many leaves to one employee
        public required virtual Employee Employee { get; set; }
    }
}


#region relationships
//شرح الحقول:
//Id: معرف فريد لكل إجازة.

//EmployeeId: يشير إلى معرف الموظف الذي أخذ الإجازة.

//LeaveType: نوع الإجازة(مثل إجازة مرضية أو إجازة سنوية أو إجازة غير مدفوعة).

//StartDate و EndDate: تاريخ بداية ونهاية الإجازة.

//Status: حالة الإجازة(تمت الموافقة، في انتظار الموافقة، تم رفضها).

//Reason: السبب الذي جعل الموظف يأخذ الإجازة.

//Employee: العلاقة مع جدول الموظفين (ربط جدول الإجازات بالموظف باستخدام EmployeeId)
#endregion