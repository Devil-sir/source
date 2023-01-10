using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }    
        public string description { get; set; }
    }
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> option):base(option) { }
        public DbSet<Product> Products { get; set; }
    }
}
