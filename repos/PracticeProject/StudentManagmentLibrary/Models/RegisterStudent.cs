using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagmentLibrary.Models
{
    public class RegisterStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public string Telephone { get; set; }
        public string EmailId { get; set; }
    }
}