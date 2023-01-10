using Microsoft.EntityFrameworkCore;

namespace CateringExample.Models
{
    public class CateringContext:DbContext
    {
        public CateringContext(DbContextOptions<CateringContext> option) : base(option) { }
        public DbSet<Category> Caterings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
