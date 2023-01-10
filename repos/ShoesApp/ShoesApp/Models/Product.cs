using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesApp.Models
{
    public class Product
    {
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Price")]
        public float price { get; set; }
        [DisplayName("Photo")]
        public string imgPath { get; set; }
        [ForeignKey("categ")]
        public int categId { get; set; }
        [DisplayName("Category Name")]
        public Category categ { get; set; }
        [NotMapped]
        [DisplayName("Image")]
        public IFormFile formFile { get; set; }
        [NotMapped]
        public int qty { get; set; }
        public bool check { get; set; } = false;

    }
}
