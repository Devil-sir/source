using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public IFormFile imgPath { get; set; }
    }
    public class CateringContext: DbContext
    {
        public CateringContext(DbContextOptions) { }
        public DbSet<Category> categories { get; set; } 
    }
}
