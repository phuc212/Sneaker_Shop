using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext context;

        public OrderDetailRepository(AppDbContext context)
        {
            this.context = context;
        }
        public decimal CalculateMoney(decimal PriceProduct, int Quantity)
        {
            throw new NotImplementedException();
        }

        public OrderDtail CreateByOrderId(int id)
        {
            OrderDtail orderDetail = new OrderDtail()
            {
                OderId = id
            };
            return orderDetail;
        }

        public int CreateOrderDetail(OrderDtail orderDetail)
        {
            List<OrderDtail> orderDetails = context.orderDtails.ToList();
            OrderDtail FindOrderDetail = orderDetails.Find(el =>
                                        el.OderId == orderDetail.OderId &&
                                        el.ProductId == orderDetail.ProductId);
            Product product = context.products.FirstOrDefault(el => el.ProductId == orderDetail.ProductId);
            
            if (orderDetails.Contains(FindOrderDetail))
            {
                FindOrderDetail.Quantity += orderDetail.Quantity;             
                context.Update(FindOrderDetail);
            }
            else
            {

                context.Add(orderDetail);
            }
            return context.SaveChanges();
        }

        public int DeleteOrderDetail(int OrderId, int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetListProductByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public Orders GetOrderByid(int id) =>
           context.orders.FirstOrDefault(el => el.OderId == id);


        public OrderDtail GetOrderDetailByIds(int ProductId, int OrderId)
        {
            var orderdetail = context.orderDtails.FirstOrDefault(el =>
                                el.ProductId == ProductId &&
                                el.OderId == OrderId);
            return (orderdetail);
        }

        public Product GetProductById(int id) =>
            context.products.FirstOrDefault(el => el.ProductId == id);



        public int UpdateOrderDetail(OrderDtail orderDetail)
        {
            context.Update(orderDetail);
            return context.SaveChanges();
        }
    }
}
