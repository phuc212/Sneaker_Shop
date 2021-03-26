using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        [MaxLength(200)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(200)]
        public string Size { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public DateTime TimeCreate { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("Category")]
        public Category category { get; set; }
        public ICollection<OrderDtail> orderDtails { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "1")]
        public decimal OriginalPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "1")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price => OriginalPrice * (1 - Discount);
    }
}
