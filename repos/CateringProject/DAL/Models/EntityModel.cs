using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Category Name")]
        [Display(Name ="Cateogry Name")]
        public string name { get; set; }
        public string photoPath { get; set; }
        [NotMapped]
        [Required(ErrorMessage ="Choose Image")]
        [Display(Name ="Category Image")]
        public IFormFile imgPath { get; set; }
    }
    public class Product
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Enter Product Name")]
        [Display(Name ="Product Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter Product Description")]
        [Display(Name = "Product Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Enter Product Price")]
        [Display(Name = "Product Price")]
        public float price { get; set; }

        public string photoPath { get; set; }
        [ForeignKey("categ")]
        public int categId { get; set; }
        public Category categ { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Choose Image")]
        [Display(Name = "Product Image")]
        public IFormFile imgPath { get; set; }

    }
    public class Inventory
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }
        [ForeignKey("categ")]
        public int categId { get; set; }
        public Category categ { get; set; }
        [Required(ErrorMessage ="Enter Product Quantity")]
        [Display(Name ="Product Quantity")]
        public int qty { get; set; }

    }
    public class Cart
    {

    }
    public class Sales
    {

    }
    public class ProductSales
    {

    }
    
}
