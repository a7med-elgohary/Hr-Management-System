using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace HR_System.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }

        [Required]
        public required Role Role { get; set; }

        //one to one
        public required virtual Employee Employee { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<AuditLog>?AuditLogs { get; set; }
    }
}

//العلاقة بين Role و UserRole
//دور واحد (Role) يمكن أن يكون مرتبطًا بعدة مستخدمين (Users).

//مستخدم واحد (User) يمكن أن يكون له دور واحد أو أكثر.



//العلاقة بين User و UserRole
//مستخدم (User) يمكن أن يكون له عدة أدوار (Roles).

//دور واحد (Role) يمكن أن يكون مرتبطًا بعدة مستخدمين (Users).

//العلاقة هنا هي many-to-many (أي أن المستخدم يمكن أن يمتلك عدة أدوار، والدور يمكن أن يكون مخصصًا لعدة مستخدمين).