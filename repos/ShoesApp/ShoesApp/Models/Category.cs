using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace ShoesApp.Models
{
    public class Category
    {
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Image")]
        public string imgPath { get; set; }
        [NotMapped]
        [DisplayName("Image")]
        public IFormFile formFile { get; set; }
    }
}
