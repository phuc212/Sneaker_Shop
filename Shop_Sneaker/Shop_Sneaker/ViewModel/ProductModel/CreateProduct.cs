using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Shop_Sneaker.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Sneaker.ViewModel.ProductModel
{
    public class CreateProduct
    {
        public int ProductId { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public string size { get; set; }
        public DateTime TimeCreate { get; set; }
        public int catelogyid { get; set; }
        [Display(Name = "Brand name")]
        public string BrandName { get; set; }
        [Range(typeof(decimal), "0", "1", ErrorMessage = "Discount must in range 0 - 1")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

    }
}
