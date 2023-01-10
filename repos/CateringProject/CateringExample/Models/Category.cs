using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CateringExample.Models
{
    public class Category
    {
            public int id { get; set; }
            [Required(ErrorMessage = "Enter Category Name")]
            [Display(Name = "Cateogry Name")]
            public string name { get; set; }
            public string photoPath { get; set; }
            [NotMapped]
            [Required(ErrorMessage = "Choose Image")]
            [Display(Name = "Category Image")]
            public IFormFile imgPath { get; set; }
        
    }
}
