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
        private readonly IAmmountRepository _ammountRepository;

        public ProductManagerService(IProductManager productManager, IProductImageRepository imageRepository, IAmmountRepository ammountRepository)
        {
            _productManager = productManager;
            _imageRepository = imageRepository;
            _ammountRepository = ammountRepository;
        }
        public async Task<int> AddProduct(AddProductViewModel product)
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

        public async Task<int> UpdateProduct(EditProductViewModel product)
        {
            Ammount quantity = new Ammount()
            {
                Quantity = product.Ammount
            };
            if (quantity.Quantity != 0)
            {
                _ammountRepository.DeleteProduct(product.Id);
            }
            List<string> images = _imageRepository.AddPathToPhoto(product.Images);
            if (images.Count != 0)
            {
                _imageRepository.RemoveItems(product.Id);
            }
            Product model = new Product()
            {
                Id = product.Id,
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
            for (int i = 0; i < images.Count; i++)
            {
                var item = new Image()
                {
                    Path = images[i]
                };
                model.Paths.Add(item);
            }
            int id =await _productManager.UpdateProduct(model);
            return id;
        }
        public  void RemoveItem(int id)
        {
            _productManager.DeleteProduct(id);
        }
    }
}
