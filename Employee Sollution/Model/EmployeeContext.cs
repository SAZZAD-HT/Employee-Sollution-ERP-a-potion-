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
        public DbSet<MonthlyReport> Report { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmployee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<tblEmployee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();

            modelBuilder.Entity<tblEmployeeAttendance>()
                .HasKey(a => new { a.EmployeeId, a.AttendanceDate });

            modelBuilder.Entity<tblEmployeeAttendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.EmployeeAttendances)
                .HasForeignKey(a => a.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }


    }

}
