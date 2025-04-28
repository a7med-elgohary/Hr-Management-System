using HR_System.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    public DbSet<Salary> Salaries { get; set; }// hint
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeTask> EmployeeTasks { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Events> events { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships between tables

        // Department - Employee (One-to-Many)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

        // Employee - Attendance (One-to-Many)
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EmployeeId);

        // Employee - Leave (One-to-Many)
        modelBuilder.Entity<Leave>()
            .HasOne(l => l.Employee)
            .WithMany(e => e.Leaves)
            .HasForeignKey(l => l.EmployeeId);

        

        // User - Role (Many-to-Many via UserRoles)
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Role - RolePermission (One-to-Many)
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

<<<<<<< HEAD
        // RolePermission - Permission (Many-to-One)
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);

 
       
=======

        // Employee - Events (1 : N)
        modelBuilder.Entity<Events>()
             .HasOne(ev => ev.Employee)
             .WithMany(emp => emp.Events)
             .HasForeignKey(ev => ev.EmployeeID)
             .OnDelete(DeleteBehavior.Restrict);;

        // Event constraint
        modelBuilder.Entity<Events>().HasKey(e => e.Id);
        modelBuilder.Entity<Events>().Property(e => e.Description).IsRequired(false);
        modelBuilder.Entity<Events>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Events>().Property(e => e.CreatedDate).IsRequired();


>>>>>>> 63d50b67c2ede265dd3a26579c40da8f90c71ead

        modelBuilder.Entity<EmployeeTask>()
            .HasOne(et => et.Employee)
            .WithMany(e => e.EmployeeTasks)
            .HasForeignKey(et => et.EmployeeId);

        
    }
}
