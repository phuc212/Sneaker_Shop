using Microsoft.AspNetCore.Identity;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderRepository(AppDbContext context,
                                UserManager<AppIdentityUser> userManager,
                                IOrderDetailRepository orderDetailRepository)
        {
            this.context = context;
            this.userManager = userManager;
            this.orderDetailRepository = orderDetailRepository;
        }

        public int AddOrderDetailInOrder(Orders order, int productId, int amount)
        {
            Product product = context.products.FirstOrDefault(el => el.ProductId == productId);
            if (context.orders.ToList().Contains(order) && product != null)
            {
                OrderDtail orderDetail = new OrderDtail()
                {
                    
                    OderId = order.OderId,
                    //ProductId = product.Id,
                    Quantity = amount
                    
                };
                context.Add(orderDetail);

                context.Update(product);
            }       
            return context.SaveChanges();
            }

        public int CreateOrder(Orders order)
        {
            context.Add(order);
            return (context.SaveChanges());
        }

        public int DeleteOrder(int id)
        {
            var order = context.orders.FirstOrDefault(el => el.OderId == id);
            if (order == null)
                return -1;
            context.Remove(order);
            return context.SaveChanges();
        }

        public ComfirmPayView GetConfirmInfo(int id)
        {
            Orders order = context.orders.FirstOrDefault(el => el.OderId == id);
            ComfirmPayView confirmPay = new ComfirmPayView()
            {
                NameCustomer = userManager.FindByIdAsync(order.CreateOder).Result.FullName,
                
                ShipDate = order.ShippedDate.ToString(),
                Total = GetTotalInAOrder(order)
            };
            return confirmPay;
        }

        public Orders GetOrder(int id) => context.orders.FirstOrDefault(el => el.OderId == id);
     

        public List<OrderDtail> GetOrderDetailsByOrderId(int id) => context.orderDtails.ToList().FindAll(el => el.OderId == id);


       public List<Orders> GetOrderList() => context.orders.ToList();
     

        public List<Orders> GetOrdersByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public double GetTotalInAOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public int PayOrder(int id)
        {
            var order = context.orders.FirstOrDefault(el => el.OderId == id);            
            context.Update(order);
            return Task.Run(async () => await context.SaveChangesAsync()).Result;
        }

        public int UpdateOrder(Orders order)
        {
            context.Update(order);
            return context.SaveChanges();
        }
    }
}
