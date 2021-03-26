using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.ProductModel
{
    public class ViewProduct
    {
        public int ProductId { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public string size { get; set; }
        public DateTime TimeCreate { get; set; }
        public int catelogyid { get; set; }
        [Display(Name = "Brand name")]
        public string BrandName { get; set; }
        
    }
}
