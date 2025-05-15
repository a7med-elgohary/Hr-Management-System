using HR_System.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Employee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public required string FullName { get; set; }
        // Email - UNIQUE and NOT NULL
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        // Address - NULLABULE
        [StringLength(200)]
        public string? Address { get; set; }

        // Phone Number - NOT NULL
        [Required]
        public required string PhoneNumber { get; set; }

        // Phone Number - NOT NULL
        [Required]
        public required string JobTitle { get; set; }

        [Required]
        public required SeniorityLevels SeniorityLevels { get; set; }
        // Hire Date - NOT NULL
        [Required]
        public DateTime? HireDate { get; set; } = DateTime.Now;

        // Salary - NOT NULL and range check
        [Required]
        [Range(0, double.MaxValue)]
        public decimal NetSalary { get; set; }
        //50,000

        //relation shipsP
        //Many Employee to One Dept
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        public required Department Department { get; set; }

        public string? Url { get; set; }
        //One to many
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Leave> Leaves { get; set; } = new List<Leave>();
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
        public ICollection<EmployeeTask> EmployeeTasks { get; set; } = new List<EmployeeTask>();
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public ICollection<Events> Events { get; set; }

        //one to one
        [ForeignKey("UserAccount")]
        public long? UserAccountId { get; set; } 
        public User? UserAccount { get; set; } 
    }
}
#region relation ships 
//1.علاقة بين Employee و Department (Many to One)
//التفاصيل:

//كل موظف ينتمي إلى قسم واحد فقط.

//قسم واحد يمكن أن يحتوي على العديد من الموظفين.

//في C#:

//خاصية DepartmentId في كلاس Employee هي المفتاح الخارجي الذي يرتبط بالقسم.

//خاصية Department في كلاس Employee تشير إلى الكائن المرتبط بقسم الموظف.

//في SQL:

//يتم استخدام المفتاح الخارجي في جدول Employee للإشارة إلى جدول Department.

//2. علاقة بين Employee و Attendance (One to Many)
//التفاصيل:

//كل موظف يمكن أن يكون لديه العديد من سجلات الحضور.

//كل سجل حضور يتبع موظفًا واحدًا فقط.

//في C#:

//خاصية Attendances في كلاس Employee هي مجموعة من الكائنات Attendance.

//خاصية EmployeeId في كلاس Attendance تشير إلى الموظف الذي يرتبط به هذا السجل.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول Attendance للإشارة إلى الموظف.

//3. علاقة بين Employee و Leave (One to Many)
//التفاصيل:

//كل موظف يمكن أن يحصل على العديد من سجلات الإجازات.

//كل سجل إجازة يتبع موظفًا واحدًا فقط.

//في C#:

//خاصية Leaves في كلاس Employee هي مجموعة من الكائنات Leave.

//خاصية EmployeeId في كلاس Leave تشير إلى الموظف الذي أخذ الإجازة.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول Leave للإشارة إلى الموظف.

//4. علاقة بين Employee و Salary (One to Many)
//التفاصيل:

//كل موظف يمكن أن يكون له العديد من سجلات الرواتب.

//كل سجل راتب يتبع موظفًا واحدًا فقط.

//في C#:

//خاصية Salaries في كلاس Employee هي مجموعة من الكائنات Salary.

//خاصية EmployeeId في كلاس Salary تشير إلى الموظف الذي يرتبط به هذا الراتب.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول Salary للإشارة إلى الموظف.

//5. علاقة بين Employee و Promotion (One to Many)
//التفاصيل:

//كل موظف يمكن أن يحصل على العديد من الترقيات.

//كل سجل ترقية يتبع موظفًا واحدًا فقط.

//في C#:

//خاصية Promotions في كلاس Employee هي مجموعة من الكائنات Promotion.

//خاصية EmployeeId في كلاس Promotion تشير إلى الموظف الذي حصل على الترقية.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول Promotion للإشارة إلى الموظف.

//6. علاقة بين Employee و EmployeeTask (One to Many)
//التفاصيل:

//كل موظف يمكن أن يكون لديه العديد من المهام الموكلة له.

//كل مهمة تتبع موظفًا واحدًا فقط.

//في C#:

//خاصية EmployeeTasks في كلاس Employee هي مجموعة من الكائنات EmployeeTask.

//خاصية EmployeeId في كلاس EmployeeTask تشير إلى الموظف الذي لديه هذه المهمة.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول EmployeeTask للإشارة إلى الموظف.

//7. علاقة بين Employee و Training (One to Many)
//التفاصيل:

//كل موظف يمكن أن يحصل على العديد من التدريبات.

//كل تدريب يتبع موظفًا واحدًا فقط.

//في C#:

//خاصية Trainings في كلاس Employee هي مجموعة من الكائنات Training.

//خاصية EmployeeId في كلاس Training تشير إلى الموظف الذي حصل على هذا التدريب.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول Training للإشارة إلى الموظف.

//8. علاقة بين Employee و User (One to One)
//التفاصيل:

//كل موظف في النظام يمكن أن يكون له حساب مستخدم واحد فقط (مثل حساب للوصول إلى النظام).

//في C#:

//خاصية User في كلاس Employee هي كائن واحد من النوع User.

//خاصية EmployeeId في كلاس User تشير إلى الموظف الذي يمتلك هذا الحساب.

//في SQL:

//يتم استخدام المفتاح الخارجي EmployeeId في جدول User للإشارة إلى الموظف الذي ينتمي إليه الحساب.

//ملخص التنظيم:
//علاقة Many to One:

//Employee->Department

//علاقة One to Many:

//Employee->Attendance

//Employee->Leave

//Employee->Salary

//Employee->Promotion

//Employee->EmployeeTask

//Employee->Training

//علاقة One to One:

//Employee->User
#endregion