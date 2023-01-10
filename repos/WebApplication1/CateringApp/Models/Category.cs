using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CateringApp.Models
{
    public class Category
    {
        [DisplayName("Id")]
        public int CategoryId { get; set; }
        [DisplayName("Name")]
        public string CategoryName { get; set; }
        [DisplayName("Photo Path")]
        public string CategoryPhotoPath { get; set; }
    }
}