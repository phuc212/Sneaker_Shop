using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(AppDbContext context,
                                IProductRepository productRepository,
                                IOrderRepository orderRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View(orderRepository.GetOrderList());
        }
        [Route("/Order/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = orderRepository.DeleteOrder(id);
            return Json(new { result });
        }
        [HttpGet]
        public IActionResult Edit(int id) => View(orderRepository.GetOrder(id));
        [HttpPost]
        public IActionResult Edit(Orders order)
        {
            if (orderRepository.UpdateOrder(order) > 0)
                return RedirectToAction("Index", "Order");
            ModelState.AddModelError("", "Error");
            return View(order);
        }
        [Route("/Order/ConfirmPay/{id}")]
        public IActionResult ConfirmPay(int id)
        {
            List<string> result = new List<string>();
            var confirmm = orderRepository.GetConfirmInfo(id);
            result.Add(confirmm.NameCustomer);
            result.Add(confirmm.CreateAt);
            result.Add(confirmm.ShipDate);
            result.Add(confirmm.Total.ToString());
            return Json(new { result });
        }
        [Route("/Order/Pay/{id}")]
        public IActionResult Pay(int id)
        {
            var result = orderRepository.PayOrder(id);
            return Json(new { result });
        }
        [HttpGet]
        public IActionResult WatchHistoryByUserId(string id) => View(orderRepository.GetOrdersByUserId(id));
    }

}
