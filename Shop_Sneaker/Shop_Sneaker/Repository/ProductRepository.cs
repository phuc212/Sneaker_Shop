using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICategoryRepository categoryRepository;

        public ProductRepository(AppDbContext context,
                                 IWebHostEnvironment webHostEnvironment,
                                 ICategoryRepository categoryRepository)
                                 
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.categoryRepository = categoryRepository;
        }
        public int Create(CreateProduct productCreate)
        {
            var count = 0;
            foreach (var item in context.products)
            {
                if (item.ProductName == productCreate.ProductName)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                var product = new Product()
                {
                    ProductName = productCreate.ProductName,
                    Description = productCreate.Description,
                    Discount = productCreate.Discount,
                    Size = productCreate.size,
                    OriginalPrice = productCreate.Price,
                    CategoryId = productCreate.catelogyid,
                    Brand = productCreate.BrandName
                };

                var fileName = string.Empty;
                if (productCreate.Image != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Product");
                    fileName = $"{Guid.NewGuid()}_{productCreate.Image.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        productCreate.Image.CopyTo(fs);
                    }
                }
                product.PathImage = fileName;
                context.products.Add(product);
                return (context.SaveChanges());
            }
            return 0;


        }

        public bool Delete(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public int Edit(EditProduct productEdit)
        {

            var product = new Product()
            {
                ProductId = productEdit.ProductId,
                ProductName = productEdit.ProductName,
                CategoryId = productEdit.catelogyid,
                Description = productEdit.Description,
                OriginalPrice = productEdit.Price,
                PathImage = productEdit.ImagePath,
                Size = productEdit.size,
                Brand = productEdit.BrandName,
            };
            var fileName = string.Empty;
            if (productEdit.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Product");
                fileName = $"{Guid.NewGuid()}_{productEdit.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    productEdit.Image.CopyTo(fs);
                }
                product.PathImage = fileName;
                if (!string.IsNullOrEmpty(productEdit.ImagePath))
                {
                    string delFile = Path.Combine(webHostEnvironment.WebRootPath,
                                        "images/Product", productEdit.ImagePath);
                    System.IO.File.Delete(delFile);
                }
            }
            if (productEdit.Image == null)
            {
                fileName = productEdit.ImagePath;
            }

            var editproduct = context.products.Attach(product);
            editproduct.State = EntityState.Modified;
            return (context.SaveChanges());

        }
        public Product Get(int id)
        {
            return context.products.Find(id);
        }

        public List<Product> Gets()
        {
            return context.products.ToList();
        }

        public object showProduct()
        {
            List<Product> products = Gets().ToList();
            List<Category> categories = categoryRepository.Gets().ToList();
            List<ShowAll> result = (from p in products
                                    join c in categories on p.CategoryId equals c.CategoryId
                                    
                                    select (new ShowAll()
                                    {
                                        ProductId = p.ProductId,
                                        ProductName = p.ProductName,
                                        Price = p.Price,
                                        CategoryName = c.CategoryName,
                                        ImagePath = p.PathImage,
                                        
                                        BrandName = p.Brand,
                                        
                                    })).ToList();
            return result;
        }

        public async Task<ICollection<ShowAll>> GetProductsInCategory(int categoryId)
        {
            return await context.products.Where(p => p.CategoryId == categoryId)
                                    .Include(p => p.category)
                                    .Select(p => new ShowAll 
                                    {
                                        BrandName = p.Brand,
                                        CategoryName = p.category.CategoryName,
                                        ImagePath = p.PathImage,
                                        Price = p.Price,
                                        ProductId = p.ProductId,
                                        ProductName = p.ProductName
                                    }).ToListAsync();
        }
    }
}
