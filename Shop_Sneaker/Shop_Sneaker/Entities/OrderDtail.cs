using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class OrderDtail
    {
        [Key]
        public int OrderDtailId { get; set; }
        
        public int ProductId { get; set; }
        [ForeignKey("Product")]
        public Product product { get; set; }
        
        public int OderId { get; set; }
        [ForeignKey("Order")]
        public Orders orders { get; set; }
        public int Quantity { get; set; }

    }
}
