using Shop_Sneaker.ViewModel.Banner;
using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.HomeViewModel
{
    public class HomeViewModel
    {
        public List<ShowAll> showAlls {get;set;}
        public List<Shop_Sneaker.Entities.Category> categories { get; set; }
        public List<BannerViewModel> bannerViewModels { get; set; }
    }
}
