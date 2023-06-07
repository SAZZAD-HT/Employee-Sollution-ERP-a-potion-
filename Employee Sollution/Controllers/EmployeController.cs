using Employee_Sollution.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Sollution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {


        private readonly EmployeeContext db;
 

        public EmployeController(EmployeeContext _db)
        {
           db = _db;
        }


        //API01# Update an employee’s Employee Code 
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployeeCode(int id, [FromBody] Updateempcode model)
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
                return NotFound();

            // Check if the new employee code already exists
            var existingEmployee = db.Employees.FirstOrDefault(e => e.EmployeeCode == model.EmployeeCode && e.EmployeeId != id);
            if (existingEmployee != null)
                return Conflict("Employee code already exists");

            // Update the employee code
            employee.EmployeeCode = model.EmployeeCode;
            db.SaveChanges();

            return Ok(employee);
        }

        //null
        //[HttpGet]
        //public async Task<IActionResult> EmployeeInfo()
        //{
           
        //    return Ok( await db.Employees.ToListAsync());
        //}

       

        // API02: Get all employees based on maximum to minimum salary
        [HttpGet("salary")]
        public IActionResult GetAllEmployees()
        {
            var employees = db.Employees.OrderByDescending(e => e.EmployeeSalary).ToList();
            return Ok(employees);
        }

        // API03: Find all employees who are absent at least one day
        [HttpGet("absent")]
        public IActionResult GetEmployeesWithAbsentDays()
        {
            var employees = db.Employees
                .Where(e => db.EmployeeAttendances.Any(a => a.EmployeeId == e.EmployeeId && a.IsAbsent == 1))
                .ToList();

            return Ok(employees);
        }


        // API04: Get monthly attendance report of all employees
        [HttpGet("attendance-report")]
        public async Task<IActionResult> GetMonthlyAttendanceReport()
        {
            RemoveAllMonthlyAttendanceReports();
            CalculateAndPushMonthlyReport();
            

            return Ok(await db.Report.ToListAsync());
        }
    
        private void CalculateAndPushMonthlyReport()
        {
            
            DateTime currentDate = DateTime.Now;
            int month = currentDate.Month;
            int year = currentDate.Year;

         
            var employeeIds = db.EmployeeAttendances
                .Where(a => a.AttendanceDate.Month == month && a.AttendanceDate.Year == year)
                .Select(a => a.EmployeeId)
                .Distinct()
                .ToList();

            
            foreach (int employeeId in employeeIds)
            {
              
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

                
                int totalPresent = db.EmployeeAttendances
                    .Count(a => a.EmployeeId == employeeId && a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.IsPresent == 1);
                int totalAbsent = db.EmployeeAttendances
                    .Count(a => a.EmployeeId == employeeId && a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.IsAbsent == 1);
                int totalOffday = db.EmployeeAttendances
                    .Count(a => a.EmployeeId == employeeId && a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.IsPresent == 1);


                var report = new MonthlyReport
                {
                    EmployeeName = employee.EmployeeName,
                    MonthName = currentDate.ToString("MMMM"),
                    TotalPresent = totalPresent,
                    TotalAbsent = totalAbsent,
                    TotalOffday = totalOffday
                };
         
                db.Report.Add(report);
            }

         
            db.SaveChanges();
        }
        private void RemoveAllMonthlyAttendanceReports()
        {
           
            var reports = db.Report.ToList();

 
           db.Report.RemoveRange(reports);


           db.SaveChanges();
        }

    }
}
