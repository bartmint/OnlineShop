using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IHostingEnvironment _hostEnvironment;
        private readonly ApplicationDb _ctx;

        public ProductImageRepository(IHostingEnvironment host, ApplicationDb ctx)
        {
            _hostEnvironment = host;
            _ctx = ctx;
        }
        public List<string> AddPathToPhoto(List<IFormFile> images)
        {
            const string dash = "_";
            const string folderName = "images";
            List<string> uniqueList = new List<string>();
            string uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, folderName);

            if (!images.Any())
            {
                return new List<string>();
            }

            foreach (var model in images)
            {
                string uniqueFileName = null;
                if (model != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + dash + model.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.CopyTo(fileStream);
                    }
                    uniqueList.Add(uniqueFileName);
                }
            }
            return uniqueList;

        }
        public async Task RemoveItems(int id)
        {
            var items = _ctx.Images.Where(p => p.ProductId == id);
            
                _ctx.RemoveRange(items);
                await _ctx.SaveChangesAsync();
            
        }


    }
}
