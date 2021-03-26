using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.RoleViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.UserViewModel
{
    public class CreateUser
    {
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Correct")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPasswork { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        //[Display(Name = "Day Of Birth")]
        //public string DoB { get; set; }
        [Display(Name = "Role")]
        [Required]
        public string RoleId { get; set; }
        public List<AppIdentityRole> Roles { get; set; }
    }
}
