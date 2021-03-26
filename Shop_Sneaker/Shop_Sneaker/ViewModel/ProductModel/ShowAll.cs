using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.ProductModel
{
    public class ShowAll
    {
        public int ProductId { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Ảnh")]
        public string ImagePath { get; set; }
        [Display(Name = " Tên loại")]
        public string CategoryName { get; set; }
        [Display(Name = "Thương hiệu")]
        public string BrandName { get; set; }

    }
}
