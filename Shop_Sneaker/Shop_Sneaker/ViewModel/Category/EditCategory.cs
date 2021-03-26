using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.Category
{
    public class EditCategory
    {
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }
        [Display(Name = "Ảnh")]
        public IFormFile Image { get; set; }
    }
}
