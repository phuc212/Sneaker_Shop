using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public interface IBanner
    {
        public List<BannerViewModel> Gets();
        public Banner Get(int id);
        public bool Delete(int id);
        public int CreateBanner(CreateBanner createBanner);
        public int UpdateBanner(Edit editBanner);
    }
}
