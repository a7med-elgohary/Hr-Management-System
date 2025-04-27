using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class RolePermission
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public required virtual Role Role { get; set; }

        [ForeignKey("Permission")]
        public long PermissionId { get; set; }
        public required virtual Permission Permission { get; set; }
    }
}
