using Shop_Sneaker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.UserViewModel
{
    public class EditUser
    {
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string RoleId { get; set; }
        public List<AppIdentityRole> Roles { get; set; }
    }
}
