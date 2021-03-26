using EmployeeMangement.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_Sneaker.Models;
using Shop_Sneaker.Repository;
using Shop_Sneaker.ViewModel.Banner;
using Shop_Sneaker.ViewModel.HomeViewModel;
using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBanner bannerRepository;

        public HomeController(ILogger<HomeController> logger,
                                IProductRepository productRepository,
                                ICategoryRepository categoryRepository,
                                IBanner bannerRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.bannerRepository = bannerRepository;
        }

        //public IActionResult Index()
        //{

        //    List<ShowAll> result = (List<ShowAll>)productRepository.showProduct();

        //    List<Shop_Sneaker.Entities.Category> categoriesShow = categoryRepository.Gets();
        //    List<BannerViewModel> bannerModels = bannerRepository.Gets();
        //    var homeView = new HomeViewModel()
        //    {
        //        bannerViewModels = bannerModels,
        //        categories = categoriesShow,
        //        showAlls = result
        //    };
        //    return View(homeView);
        //}

        //[AllowAnonymous]
        public async Task<IActionResult> Index(int currenPage, int pageSize, int categoryId)
        {
            var categories = categoryRepository.Gets();
            List<ShowAll> products = new List<ShowAll>();
            if (categoryId > 0 && categories != null)
            {
                products = (await productRepository.GetProductsInCategory(categoryId)).ToList();
            }
            else
            {
                if (categories.Any())
                {
                    products = (await productRepository.GetProductsInCategory(categories[0].CategoryId)).ToList();
                }
            };
            if (currenPage == 0)
            {
                currenPage = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 8;
            }

            var pager = new Pager(products.Count, currenPage, pageSize);
            var pagination = new Pagination<ShowAll>()
            {
                ListItems = products.Skip((currenPage - 1) * pageSize).Take(pageSize),
                Pager = pager,
                bannerModels = bannerRepository.Gets(),
                categoriesShow = categories
            };
            return View(pagination);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
