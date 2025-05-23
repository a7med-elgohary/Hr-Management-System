﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HR_System.Domain.Models.Enums;

namespace HR_System.Domain.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Status Status { get; set; } = Status.Pending;  // Default value

        // Foreign Key for the manager (Employee responsible for the project)
        [ForeignKey("Manager")]
        public long? ManagerId { get; set; }

        public required Employee Manager { get; set; }  // Navigation Property

        // Additional fields for budget and description
        public decimal Budget { get; set; } = 0;  // Default value

        public string? Description { get; set; }



        ICollection<EmployeeTask> EmployeeTasks { get; set; } = new List<EmployeeTask>();
        ICollection<Task> Tasks { get; set; } = new List<Task>();



    }
}