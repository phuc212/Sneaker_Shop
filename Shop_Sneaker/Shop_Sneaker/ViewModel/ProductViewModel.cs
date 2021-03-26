using Shop_Sneaker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        [MaxLength(200)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(200)]
        public string Size { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public int categoryid { get; set; }
        //public Category category { get; set; }
        [Required]
        public int OriginalPrice { get; set; }
        [Range(0, 1)]
        public int Discount { get; set; }
        public int Price => OriginalPrice * (1 - Discount);
    }
}
