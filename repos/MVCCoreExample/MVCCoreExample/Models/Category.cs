using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreExample.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public IFormFile imgPath { get; set; }
    }
    public class CateringContext : DbContext
    {
        public CateringContext(DbContextOptions<CateringContext> option):base(option)
        {

        }
        public DbSet<Category> categories { get; set; }
    }
}
