using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
   public  class ProductsListService:IProductsListService
    {
        private readonly IProductsListRepository _repository;

        public ProductsListService(IProductsListRepository repository)
        {
            _repository = repository;
        }

        public async  Task<IEnumerable<Product>> GetProducts()
        {
            var items = await _repository.GetProducts();//pobieram produkty
            return items;
        }
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
    }
}
