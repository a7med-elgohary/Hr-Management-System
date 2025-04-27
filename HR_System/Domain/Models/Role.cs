using System.ComponentModel.DataAnnotations;

namespace HR_System.Domain.Models
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public virtual ICollection<RolePermission>? RolePermissions { get; set; }

        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}

#region
//العلاقة بين Role و RolePermission
//كل دور (Role) يمكن أن يكون له عدة صلاحيات (Permissions). لذا، العلاقة بين Role و RolePermission هي علاقة واحد إلى كثير (One-to-Many).

//دور واحد (Role) يمكن أن يحتوي على عدة صلاحيات (Permissions).

//كل صلاحية (Permission) تكون مرتبطة بدور معين

#endregion