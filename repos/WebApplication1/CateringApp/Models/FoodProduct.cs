using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CateringApp.Models
{
    public class FoodProduct
    {
        [DisplayName("Id")]
        public int FoodProductId { get; set; }
        [DisplayName("Name")]
        public string FoodProductName { get; set; }
        [DisplayName("Category Id")]
        public int FPCategoryId { get; set; }
        [DisplayName("Description")]
        public string FoodProductDescription { get; set; }
        [DisplayName("Price")]
        public float FoodProductPrice { get; set; }
        [DisplayName("Photo Path")]
        public string FoodProductPhotoPath { get; set; }

    }
}