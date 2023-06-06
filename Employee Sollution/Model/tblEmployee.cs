using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employee_Sollution.Model
{
    public class tblEmployee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [MaxLength(10)]
       
        public string EmployeeCode { get; set; }

        public decimal EmployeeSalary { get; set; }

        [ForeignKey("EmployeeId")]
        public List<tblEmployeeAttendance> EmployeeAttendances { get; set; }

    }
}
