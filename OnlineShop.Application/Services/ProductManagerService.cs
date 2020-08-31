using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class ProductManagerService:IProductManagerService
    {
        private readonly IProductManager _productManager;
        private readonly IProductImageRepository _imageRepository;

        public ProductManagerService(IProductManager productManager, IProductImageRepository imageRepository)
        {
            _productManager = productManager;
            _imageRepository = imageRepository;
        }
        public async Task<int> CreateProduct(CreateProductViewModel product)
        {
            Ammount quantity = new Ammount()
            {
                Quantity = product.Ammount
            };
            List<string> images = _imageRepository.AddPathToPhoto(product.Images);
            Product model = new Product()
            {
                ProductionCompany = product.ProductionCompany,
                Model = product.Model,
                System = product.System,
                CPU = product.CPU,
                MemoryType = product.MemoryType,
                HardDrive = product.HardDrive,
                Weight = product.Weight,
                GraphicCard = product.GraphicCard,
                Value = product.Value,
                ProductionYear = product.ProductionYear,
                ScreenResolution = product.ScreenResolution,
                Description = product.Description,
                Warranty = product.Warranty,
                Ammount = quantity,
                Paths = new List<Image>()
            };
            for(int i=0; i<images.Count; i++)
            {
                var item = new Image()
                {
                    Path = images[i]
                };
                model.Paths.Add(item);
            }
            int id=await _productManager.CreateProduct(model);
            return id;
        }
        public Product GetProduct(int id)
        {
            return  _productManager.GetProductById(id);
        }
    }
}
