using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        [DisplayName("Id")]
        public int CategoryId { get; set; }
        [DisplayName("Name")]
        public string CategoryName { get; set; }
        [DisplayName("Photo Path")]
        public string CategoryPhotoPath { get; set; }
    }
    public class FoodProduct
    {
        [DisplayName("Id")]
        public int FoodProductId { get; set; }
        [DisplayName("Name")]
        public string FoodProductName { get; set; }
        [DisplayName("Category Id")]
        [ForeignKey("Fp")]
        public int FPCategoryId { get; set; }

        public FoodProduct Fp { get; set; }
        [DisplayName("Description")]
        public string FoodProductDescription { get; set; }
        [DisplayName("Price")]
        public float FoodProductPrice { get; set; }
        [DisplayName("Photo Path")]
        public string FoodProductPhotoPath { get; set; }

    }
    public class CateringAppContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<FoodProduct> foodProducts { get; set; }
    }

}
