using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IProductsListRepository _productsListRepository;

        public ProductManagerService(IProductManager productManager, IProductImageRepository imageRepository,
            IAmmountRepository ammountRepository, IMapper mapper, IProductsListRepository productsListRepository)
        {
            _productManager = productManager;
            _imageRepository = imageRepository;
            _ammountRepository = ammountRepository;
            _mapper = mapper;
            _productsListRepository = productsListRepository;
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
        public ListProductsVM GetProducts(int? pageNumber, string searchString)
        {
            const int pageSize = 8;
            var items = _productsListRepository.GetProducts();
            
            if (!String.IsNullOrEmpty(searchString))//jesli nie jest a on nie jest bo bierze current filter zasraniec
            {
                items = items.Where(s => s.Model.Contains(searchString));
            }
            
            Paginate paginate = new Paginate(items.Count(), pageNumber.Value, pageSize);

            items = items.Skip(pageSize * (pageNumber.Value - 1)).Take(pageSize);

            ListProductsVM testPaginationVM = new ListProductsVM();
            testPaginationVM.Paginate = paginate;
            testPaginationVM.Products = (items.ProjectTo<ProductForListVM>(_mapper.ConfigurationProvider)).ToList();

            testPaginationVM.Count = items.Count();

            return testPaginationVM;
        }
    }
}
