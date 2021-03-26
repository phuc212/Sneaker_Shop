using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class OrderDetailController: Controller
    {
        private readonly AppDbContext context;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailController(AppDbContext context,
                                IProductRepository productRepository,
                                IOrderRepository orderRepository,
                                IOrderDetailRepository orderDetailRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WatchOrderDetail(int id) =>
            View(orderDetailRepository.GetOrderByid(id));
        [HttpGet]
        public IActionResult Create(int id) =>
            View(orderDetailRepository.CreateByOrderId(id));
        [HttpPost]
        public IActionResult Create(OrderDtail orderDetail)
        {
            if (ModelState.IsValid)
            {
                if (orderDetailRepository.CreateOrderDetail(orderDetail) > 0 && orderDetail.Quantity > 0)
                    return RedirectToAction("WatchOrderDetail", "OrderDetail", orderDetailRepository.GetOrderByid(orderDetail.OderId));
                ModelState.AddModelError("", "Quantity is not Null");
            }
            else
                ModelState.AddModelError("", "Error");
            return View(orderDetail);
        }
        public JsonResult GetProductsByCategoryId(int id) =>
             Json(new SelectList(orderDetailRepository.GetListProductByCategoryId(id), "Id", "Name"));
        [Route("/OrderDetail/GetPrice/{ProductId}/{Discount}/{Quantity}")]
        //public JsonResult GetPrice(int ProductId, int Discount, int Quantity)
        //{
        //    Product product = orderDetailRepository.GetProductById(ProductId);
        //    return Json(detailRepository.CalculateMoney(product.PricePerUnit, Discount, Quantity));
        //}
        public JsonResult DefaultByProductId(int id)
        {
            Product product = orderDetailRepository.GetProductById(id);
            return Json(product.Price);
        }
        [HttpGet]
        public IActionResult Edit(int ProductId, int OrderId) =>
            View(orderDetailRepository.GetOrderDetailByIds(ProductId, OrderId));
        [HttpPost]
        public IActionResult Edit(OrderDtail orderDetail)
        {
            if (orderDetailRepository.UpdateOrderDetail(orderDetail) > 0)
                return RedirectToAction("WatchOrderDetail", "OrderDetail", orderDetailRepository.GetOrderByid(orderDetail.OderId));
            return View(orderDetail);
        }
        [Route("/OrderDetail/Delete/{OrderId}/{ProductId}")]
        public IActionResult Delete(int OrderId, int ProductId)
        {
            var result = orderDetailRepository.DeleteOrderDetail(OrderId, ProductId);
            return Json(new { result });
        }
    }
}
