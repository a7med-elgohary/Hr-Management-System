using System.ComponentModel.DataAnnotations;

namespace HR_System.Domain.Models
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
