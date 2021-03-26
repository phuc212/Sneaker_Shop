using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public interface ICategoryRepository
    {
        List<Category> Gets();
        Category Get(int id);
        bool Delete(int id);
        int CreateCategory(CreateCategory categoryCreate);
        int UpdateCategory(EditCategory categoryEdit);

    }
}
