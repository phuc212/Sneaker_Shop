using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Repository;
using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class ProductController : Controller
    {

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductController(IProductRepository productRepository,
                                ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<ShowAll> result = (List<ShowAll>)productRepository.showProduct();
            return View(result);
        }
    
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categoryRepository.Gets();
            return View();
        }
         [HttpPost]
        public IActionResult Create(CreateProduct model)
        {
            ViewBag.Categories = categoryRepository.Gets();
            if (ModelState.IsValid)
            {
                if (productRepository.Create(model) > 0)
                    return RedirectToAction(actionName:"Index",controllerName:"Product");
                else
                    ModelState.AddModelError("", "Tên này đã tồn tại, vui lòng thử lại tên khác!");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = categoryRepository.Gets();
            try
            {
                var product = productRepository.Get(id);
                if (product != null)
                {
                    var productedit = new EditProduct()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        catelogyid = product.CategoryId,
                        Description = product.Description,
                        Price = product.Price,
                        ImagePath = product.PathImage,
                        size = product.Size,
                        BrandName = product.Brand,
                        
                    };
                    return View(productedit);
                }
                else
                {
                    ViewBag.id = id;
                    return View("~/Views/Error/ProductNotFound.cshtml");
                }
            }
            catch (Exception)
            {
                ViewBag.id = id;
                return View("~/Views/Error/ProductNotFound.cshtml");
            }
        }
        [HttpPost]
        public IActionResult Edit(EditProduct model)
        {
            if (ModelState.IsValid)
            {
                if (productRepository.Edit(model) > 0)
                {
                    return RedirectToAction("Index", "Product", new { categoryid = model.catelogyid });
                }
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var product = productRepository.Get(id);
            if (productRepository.Delete(id))
            {
                return RedirectToAction("ProductbyCategory", "Product", new { categoryid = product.CategoryId });
            }
            return View();
        }
        public IActionResult Profile(int id)
        {
            var product = productRepository.Get(id);
            product.Brand = categoryRepository.Gets().Single(p => p.CategoryId == product.CategoryId).CategoryName;
            return View(product);
        }
        public IActionResult Detail(int id)
        {
            var product = productRepository.Get(id);
            var model = new ViewProduct()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                BrandName = product.Brand,
                ImagePath = product.PathImage,
                Price = product.Price,
                catelogyid = product.CategoryId,
                Description = product.Description,
                size =product.Size
                
            };
            return View(model);
        }

    }
}
