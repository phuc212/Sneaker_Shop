using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.ProductModel
{
    public class EditProduct
    {

   
        public IFormFile Image { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string size { get; set; }
        public int catelogyid { get; set; }
        [Display(Name = "Brand name")]
        public string BrandName { get; set; }
    }
}
