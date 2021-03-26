using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class Cart
    {
        [Key,ForeignKey("AppIdentityUser")]
        public int UserId { get; set; }
        public AppIdentityUser appIdentity { get; set; }
        public ICollection<CartDetail> cartDetails { get; set; }
    }
}
