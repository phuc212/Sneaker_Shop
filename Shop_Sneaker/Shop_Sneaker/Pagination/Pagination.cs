using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Pagination
{
    public class Pagination<T> where T : class
    {
        public IEnumerable<T> ListItems { get; set; }
        public List<Category> categoriesShow { get; set; }
        public List<BannerViewModel> bannerModels { get; set; }
        public Pager Pager { get; set; }
    }
}
