using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Repository;
using Shop_Sneaker.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var Categories = categoryRepository.Gets();
            return View(Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategory model)
        {
            if (ModelState.IsValid)
            {
                if (categoryRepository.CreateCategory(model) > 0)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Tên Danh Mục Đả Tồn Tại");
                    return View(model);
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryRepository.Get(id);
            var editcategory = new EditCategory()
            {
                ImagePath = category.Logo,
                CategoryName = category.CategoryName,
                CategoryId = category.CategoryId,

            };
            return View(editcategory);

        }
        [HttpPost]
        public IActionResult Edit(EditCategory model)
        {
            if (ModelState.IsValid)
            {
                if (categoryRepository.UpdateCategory(model) > 0)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Category");
                }
                else ModelState.AddModelError("", "Tên này đã tồn tại, vui lòng chọn tên khác");
            }
            return View();
        }
    }
}
