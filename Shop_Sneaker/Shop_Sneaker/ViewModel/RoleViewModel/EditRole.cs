using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Views.Role
{
    public class EditRole
    {
        public string RoleId { get; set; }
        [Required]
        [Display(Name = "Name Of Role")]
        public string RoleName { get; set; }
    }
}
