using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Repository;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class BannerController :Controller
    {
        private readonly IBanner bannerRepositori;

        public BannerController(IBanner bannerRepositori)
        {
            this.bannerRepositori = bannerRepositori;
        }
        public IActionResult Index()
        {
            var banners = bannerRepositori.Gets();
            return View(banners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = bannerRepositori.Gets();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBanner model)
        {
            ViewBag.Categories = bannerRepositori.Gets();
            if (ModelState.IsValid)
            {
                if (bannerRepositori.CreateBanner(model) > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Tên này đã tồn tại, vui lòng thử lại tên khác!");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var banner = bannerRepositori.Get(id);
            var editBanner = new Edit()
            {
                BannerPhoto = banner.BannerPhoto,
                BannerName = banner.BannerName,
                BannerId = banner.BannerId,

            };
            return View(editBanner);

        }
        [HttpPost]
        public IActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                if (bannerRepositori.UpdateBanner(model) > 0)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Banner");
                }
                else ModelState.AddModelError("", "Tên này đã tồn tại, vui lòng chọn tên khác");
            }
            return View();
        }
    }

}
