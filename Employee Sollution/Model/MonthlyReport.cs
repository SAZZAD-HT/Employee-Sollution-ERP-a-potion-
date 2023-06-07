using System.ComponentModel.DataAnnotations;

namespace Employee_Sollution.Model
{
    public class MonthlyReport
    {
        [Key]
       public string EmployeeName { get; set; }
 
       
        public string MonthName { get; set; }

       
        public int TotalPresent { get; set; }

      
        public int TotalAbsent { get; set; }

     
        public int TotalOffday { get; set; }
    }
}
