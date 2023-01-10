using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EntityModel
    {
        
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
