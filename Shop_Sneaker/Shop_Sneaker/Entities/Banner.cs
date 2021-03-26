using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Entities
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string BannerPhoto { get; set; }
        public string Description { get; set; }
    }
}
