using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.Account
{
    public class RegisterViewModel
    {
        [MaxLength(200)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Remote("EmailInUse", "Account")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password not match.")]
        [Display(Name = "Confirm password")]
        [MaxLength(50)]
        public string ConfirmPassword { get; set; }
        public bool Gender { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
