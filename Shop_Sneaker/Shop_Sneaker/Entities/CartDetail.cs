using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        
        public int ProductId { get; set; }
        [ForeignKey("Product")]
        public Product product { get; set; }
        public int UserId { get; set; }
        public Cart cart { get; set; }

    }
}
