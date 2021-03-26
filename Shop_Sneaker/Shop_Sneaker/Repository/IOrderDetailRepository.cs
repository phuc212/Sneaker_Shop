using Shop_Sneaker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public interface IOrderDetailRepository
    {
        Orders GetOrderByid(int id);
        OrderDtail CreateByOrderId(int id);
        int CreateOrderDetail(OrderDtail orderDetail);
        List<Product> GetListProductByCategoryId(int id);
        decimal CalculateMoney(decimal PriceProduct, int Quantity);
        Product GetProductById(int id);
        OrderDtail GetOrderDetailByIds(int ProductId, int OrderId);
        int UpdateOrderDetail(OrderDtail orderDetail);
        int DeleteOrderDetail(int OrderId, int ProductId);
    }
}
