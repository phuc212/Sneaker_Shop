using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class AppIdentityUser : IdentityUser
    {
        
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        
        public ICollection<Orders> orders { get; set; }
    }
}
