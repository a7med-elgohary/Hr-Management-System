using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Domain.Models
{
    public class ProjectFile
    {
        public long Id { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public byte[] Content { get; set; }  // هنا يتم تخزين الملف فعليًا

        public DateTime UploadedAt { get; set; }

        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

    }
}
