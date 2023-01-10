using Microsoft.EntityFrameworkCore;

namespace EmployeeDirc.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public float salary { get; set; }

    }
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> option): base(option) { }
        public DbSet<Employee> Employees { get; set; }  
    }
}
