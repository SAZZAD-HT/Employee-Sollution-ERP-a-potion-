using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Sollution.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {
        }
        public DbSet<tblEmployee> Employees { get; set; }
        public DbSet<tblEmployeeAttendance> EmployeeAttendances { get; set; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<tblEmployee>()
            .HasKey(e => e.employeeId);

        modelBuilder.Entity<tblEmployee>()
            .Property(e => e.employeeCode)
            .HasAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

        modelBuilder.Entity<tblEmployeeAttendance>()
            .HasKey(a => new { a.employeeId, a.attendanceDate });

        modelBuilder.Entity<tblEmployeeAttendance>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.EmployeeAttendances)
            .HasForeignKey(a => a.employeeId);
    }
}
