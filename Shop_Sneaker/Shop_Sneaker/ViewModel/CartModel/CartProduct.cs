using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.ViewModel.CartModel
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public decimal UniPrice { get; set; }
    }
}
