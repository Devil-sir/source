using Microsoft.EntityFrameworkCore;
using ShoesApp.Models;

namespace ShoesApp.Models
{
    public class ShoesContext:DbContext
    {
        public ShoesContext(DbContextOptions<ShoesContext> option): base(option) { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<ProductsSold> productsSold { get; set; }
    }
}
