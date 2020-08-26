using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IHostingEnvironment _hostEnvironment;

        public ProductImageRepository(IHostingEnvironment host)
        {
            _hostEnvironment=host;

        }
        public List<string> AddPathToPhoto(List<IFormFile> images)
        {
            const string dash = "_";
            const string folderName = "images";
            List<string> uniqueList = new List<string>();

            if (!images.Any())
            {
                return new List<string>();//always return empty list instead of null
            }

            foreach (var model in images)
            {
                string uniqueFileName = null;
                if (model != null)
                {
                    string uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, folderName);
                    uniqueFileName = Guid.NewGuid().ToString() + dash + model.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                         model.CopyToAsync(fileStream);
                    }
                    uniqueList.Add(uniqueFileName);
                }
            }
            return uniqueList;

        }
        

        
    }
}
