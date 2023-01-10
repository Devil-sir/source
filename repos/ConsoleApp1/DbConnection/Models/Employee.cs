using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.Models
{
    internal class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public int empSalary { get; set; }
        public string empDepartment { get; set; }
    }
}
