using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesApp.Models
{
    public class ProductsSold
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }
        [ForeignKey("sale")]
        public int saleId { get; set; }
        public Sale sale { get; set; }
        public int qty { get; set; }
    }
}
