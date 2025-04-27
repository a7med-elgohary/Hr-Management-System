using System.ComponentModel.DataAnnotations;

namespace HR_System.Domain.Models
{
    public class AuditLog
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public required string Action { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Relationship with User
        public required virtual User User { get; set; }
    }
}
