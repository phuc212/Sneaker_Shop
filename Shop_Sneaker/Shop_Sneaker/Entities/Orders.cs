using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class Orders
    {
        [Key]
        public int OderId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CreateOder { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippedDate { get; set; }
        [Required]
        public long Freight { get; set; }
        [Required]
        [MaxLength(200)]
        public string ShipAddress { get; set; }
        public ICollection<OrderDtail> orderDtails { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("AppIdentityUser")]
        public AppIdentityUser user { get; set; }

    }
}
