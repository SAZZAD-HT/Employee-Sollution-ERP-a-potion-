using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee_Sollution.Model
{
    public class tblEmployeeAttendance
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime AttendanceDate { get; set; }

        public int IsPresent { get; set; }

        public int IsAbsent { get; set; }

        public int IsOffday { get; set; }

        public tblEmployee Employee { get; set; }
    }
}
