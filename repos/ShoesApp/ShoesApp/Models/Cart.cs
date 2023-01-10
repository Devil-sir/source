using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesApp.Models
{
    public class Cart
    {
        public int id { get; set; }
        [ForeignKey("categ")]
        public int categId { get; set; }
        public Category categ { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }
        public string userId { get; set; }

        public int qty { get; set; }
    }
}
