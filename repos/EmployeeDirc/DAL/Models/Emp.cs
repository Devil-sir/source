using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Emp
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public string imgPath { get; set; }
        [NotMapped]
        public IFormFile photo { get; set; }
    }
    public class EmpContext: DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> option) : base(option) { }
        public DbSet<Emp> Emps { get; set; }
    }
}
