using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public interface IOrderRepository
    {
        public int CreateOrder(Orders order);
        public List<Orders> GetOrderList();
        public int DeleteOrder(int id);
        public Orders GetOrder(int id);
        public int UpdateOrder(Orders order);
        public ComfirmPayView GetConfirmInfo(int id);
        public double GetTotalInAOrder(Orders order);
        public int PayOrder(int id);
        public int AddOrderDetailInOrder(Orders order, int productId, int amount);
        public List<OrderDtail> GetOrderDetailsByOrderId(int id);
        public List<Orders> GetOrdersByUserId(string id);
    }
}
