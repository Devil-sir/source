using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        [DisplayName("Id")]
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Photo Path")]
        public string CategoryPhotoPath { get; set; }
    }
    public class FoodProduct
    {
        [DisplayName("Id")]
        public int FoodProductId { get; set; }
        [DisplayName("Product Name")]
        public string FoodProductName { get; set; }
        [DisplayName("Category Id")]

        [ForeignKey("categ")]
        public int FPCategoryId { get; set; }
        public Category categ { get; set; }

        [DisplayName("Description")]
        public string FoodProductDescription { get; set; }
        [DisplayName("Price")]
        public float FoodProductPrice { get; set; }
        [DisplayName("Photo Path")]
        public string FoodProductPhotoPath { get; set; }
        [NotMapped]
        public int Qty { get; set; }
        public bool check { get; set; } = false;

    }
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        [ForeignKey("fp")]
        public int FoodProductId { get; set; }

        public FoodProduct fp { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        [NotMapped]
        public float TotalPrice { get; set; }
    }
    public class Inventory
    {
        public int InventoryId { get; set; }
        [ForeignKey("fp")]
        public int pId { get; set; }
        public FoodProduct fp { get; set; }
        [ForeignKey("categ")]
        public int categId { get; set; }
        public Category categ { get; set; }
        public float qty { get; set; }    
    }
    public class CateringAppContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<FoodProduct> foodProducts { get; set; }
        public DbSet<Purchase> purchases { get; set; }  
        public DbSet<Inventory> inventories { get; set; }
    }

}
