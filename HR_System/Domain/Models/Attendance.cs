using HR_System.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class Attendance // الحصور والانصراف 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        public DateTime DayDate { get; set; } = DateTime.Today;

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }
        public required virtual Employee Employee { get; set; }
    }
}
#region

//شرح الحقول:
//Id: معرف فريد لكل سجل في جدول الحضور.

//EmployeeId: يشير إلى معرف الموظف الذي يتصل بهذا السجل.

//Date: التاريخ الذي يتم فيه تسجيل الحضور (يوم العمل).

//CheckInTime: وقت دخول الموظف (إذا كان موجودًا).

//CheckOutTime: وقت مغادرة الموظف.

//Status: حالة الموظف في هذا اليوم (مثل "حاضر"، "غائب"، "متأخر"، أو "في إجازة").

//Employee: العلاقة مع جدول الموظفين (ربط جدول الحضور بالموظف باستخدام EmployeeId).
#endregion