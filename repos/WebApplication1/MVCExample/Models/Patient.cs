using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
    }
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> patient { get; set; }
    }
}