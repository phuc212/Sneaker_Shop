using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.Category
{
    public class CreateCategory
    {
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }
        [Display(Name = "Image")]
        public IFormFile CategoryImage { get; set; }
        public DateTime CreateAt { get; set; }
        public string Logo { get; set; }
    }
}
