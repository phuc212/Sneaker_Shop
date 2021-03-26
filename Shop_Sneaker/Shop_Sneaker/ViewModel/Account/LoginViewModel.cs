using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Ten Dang Nhap")]

        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remenber me")]
        public bool RemenberMe { get; set; }
    }
}
