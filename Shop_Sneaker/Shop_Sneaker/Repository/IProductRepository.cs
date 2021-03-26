using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public interface IProductRepository
    {
       public List<Product> Gets();
       public Product Get(int id);
       public bool Delete(int id);
       public int Create(CreateProduct productCreate);
       public int Edit(EditProduct productEdit);
       public object showProduct();
       Task<ICollection<ShowAll>> GetProductsInCategory(int categoryId);



    }
}
