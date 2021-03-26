using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(200)]
        public string CategoryName { get; set; }
        public ICollection<Product> Product { get; set; }
        public DateTime CreateAt { get; set; }
        public string Logo { get; set; }
    }
}
