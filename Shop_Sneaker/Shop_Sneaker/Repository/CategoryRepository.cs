using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryRepository(AppDbContext context,
                                  IWebHostEnvironment webHostEnvironment) 
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public int CreateCategory(CreateCategory categoryCreate)
        {
            var count = 0;
            foreach (var item in context.categories)
            {
                if (item.CategoryName == categoryCreate.CategoryName)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                var category = new Category()
                {
                    CategoryName = categoryCreate.CategoryName,
                    CreateAt = categoryCreate.CreateAt,
                };
                var fileName = string.Empty;
                if (categoryCreate.CategoryImage != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Category");
                    fileName = $"{Guid.NewGuid()}_{categoryCreate.CategoryImage.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        categoryCreate.CategoryImage.CopyTo(fs);
                    }
                }
                if (categoryCreate.CategoryImage == null)
                {
                    fileName = "nonCat.jpg";
                }
                category.Logo = fileName;
                context.categories.Add(category);
                return context.SaveChanges();
            }
            return 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return context.categories.Find(id);
        }

        public List<Category> Gets()
        {
            return context.categories.ToList();
        }

        public int UpdateCategory(EditCategory categoryEdit)
        {
            var category = new Category()
            {
                CategoryName = categoryEdit.CategoryName,
                CategoryId = categoryEdit.CategoryId,
                Logo = categoryEdit.ImagePath,
            };

            var fileName = string.Empty;
            if (categoryEdit.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Category");
                fileName = $"{Guid.NewGuid()}_{categoryEdit.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    categoryEdit.Image.CopyTo(fs);
                }
                category.Logo = fileName;
                if (!string.IsNullOrEmpty(categoryEdit.ImagePath))
                {
                    string delFile = Path.Combine(webHostEnvironment.WebRootPath,
                                        "images/Category", categoryEdit.ImagePath);
                    System.IO.File.Delete(delFile);
                }
            }
            else
            {
                fileName = categoryEdit.ImagePath;
            }
            category.Logo = fileName;
            var editcategory = context.categories.Attach(category);
            editcategory.State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
