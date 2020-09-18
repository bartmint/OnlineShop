using AutoMapper;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.Product;
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
        private readonly IMapper _mapper;

        public ProductManagerService(IProductManager productManager, IProductImageRepository imageRepository, IAmmountRepository ammountRepository, IMapper mapper)
        {
            _productManager = productManager;
            _imageRepository = imageRepository;
            _ammountRepository = ammountRepository;
            _mapper = mapper;
        }
        public async Task<int> AddProduct(NewProductVM product)//do poprawy
        {
            var model = _mapper.Map<Product>(product);
            model.Ammount = new Ammount() { Quantity = product.Ammount };

            List<string> images = _imageRepository.AddPathToPhoto(product.Images);
            for (int i=0; i<images.Count; i++)
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
        

        public async Task<int> UpdateProduct(NewProductVM product)
        {
            var model = _mapper.Map<Product>(product);
            model.Ammount = new Ammount() { Quantity = product.Ammount };

            List<string> images = _imageRepository.AddPathToPhoto(product.Images);
            for (int i = 0; i < images.Count; i++)
            {
                var item = new Image()
                {
                    Path = images[i]
                };
                model.Paths.Add(item);
            }

            if(images.Count!=0)
                await _imageRepository.RemoveItems(product.Id);
            if(model.Ammount!=null)
                await _ammountRepository.DeleteAmmount(product.Id);
            
            int id =await _productManager.UpdateProduct(model);
            return id;
        }
        public  void RemoveItem(int id)
        {
            _productManager.DeleteProduct(id);
        }
        public NewProductVM GetProduct(int id)
        {
            var model = _productManager.GetProductById(id);
            var item = _mapper.Map<NewProductVM>(model);

            return  item;
        }
    }
}
