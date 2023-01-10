using System.ComponentModel.DataAnnotations.Schema;

namespace CateringExample.Models
{
    public class Inventory
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }
        public int qty { get; set; }
    }

}
