using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class UserRole
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public required virtual User User { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public required virtual Role Role { get; set; }
    }
}
