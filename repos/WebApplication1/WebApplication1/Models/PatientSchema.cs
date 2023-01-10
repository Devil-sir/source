using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PatientSchema
    {
        public int Id {get; set;}
        public string Name { get; set; }
        //public string PatientDescription { get; set; }
        public int Age { get; set; } 
    }
}