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

        public  IEnumerable<Product> GetProducts()
        {
            var items = _repository.GetProducts();
            return items.Result;
        }
       
    }
}
