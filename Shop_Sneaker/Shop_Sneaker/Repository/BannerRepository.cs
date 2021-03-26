using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class BannerRepository : IBanner
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BannerRepository(AppDbContext context,
                                  IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public int CreateBanner(CreateBanner createBanner)
        {
            var count = 0;
            foreach (var item in context.banners)
            {
                if (item.BannerName == createBanner.BannerName)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                var fileName = string.Empty;
                if (createBanner.BannerImage != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Banner");
                    fileName = $"{Guid.NewGuid()}_{createBanner.BannerImage.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        createBanner.BannerImage.CopyTo(fs);
                    }
                }
                if (createBanner.BannerImage == null)
                {
                    fileName = "nonCat.jpg";
                }

                Banner newBanner = new Banner()
                {
                    BannerName = createBanner.BannerName,
                    BannerPhoto = fileName,
                    Description = createBanner.Description
                };
                context.banners.Add(newBanner);
                return (context.SaveChanges());
            }
            return 0;


        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Banner Get(int id)
        {
            return context.banners.Find(id);
        }

        public List<BannerViewModel> Gets()
        {
            return context.banners.Select(b => new BannerViewModel 
                                                        {
                                                         BannerId = b.BannerId,
                                                         BannerName = b.BannerName,
                                                         BannerPhoto = b.BannerPhoto,
                                                         Description = b.Description
                                                        }).ToList();
        }

        public int UpdateBanner(Edit editBanner)
        {
            var banner = new Banner()
            {
                BannerName = editBanner.BannerName,
                BannerId = editBanner.BannerId,
                BannerPhoto = editBanner.BannerPhoto,
            };

            var fileName = string.Empty;
            if (editBanner.BannerImage != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Banner");
                fileName = $"{Guid.NewGuid()}_{editBanner.BannerImage.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    editBanner.BannerImage.CopyTo(fs);
                }
                banner.BannerPhoto = fileName;
                if (!string.IsNullOrEmpty(editBanner.BannerPhoto))
                {
                    string delFile = Path.Combine(webHostEnvironment.WebRootPath,
                                        "images/Banner", editBanner.BannerPhoto);
                    System.IO.File.Delete(delFile);
                }
            }
            else
            {
                fileName = editBanner.BannerPhoto;
            }
            banner.BannerPhoto = fileName;
            var banneredit = context.banners.Attach(banner);
            banneredit.State = EntityState.Modified;
            return context.SaveChanges();
        }
    
    }
}
