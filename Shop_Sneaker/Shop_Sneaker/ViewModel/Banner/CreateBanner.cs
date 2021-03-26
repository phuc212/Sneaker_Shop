using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.Banner
{
    public class CreateBanner
    {

        public string BannerName { get; set; }
        public string BannerPhoto { get; set; }
        public string Description { get; set; }
        public IFormFile BannerImage { get; set; }
    }
}
