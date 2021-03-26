using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.CartModel
{
    public class CartItem
    {
        public int quantity { set; get; }
        public CartProduct product { set; get; }
    }
}
