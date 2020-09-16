using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async  Task<List<Product>> GetProducts(int pageSize, int pageNumber, string searchString, string sortOrder, string currentFilter)
        {
            //tutaj zostaja przekazane odpowiednie filtry + paginacja i dopiero przygotowane dane zostana pobrane z bazy
            var items = await _repository.GetProducts().Where(p => p.Model.Contains(searchString)).ToListAsync();

            return items;
        }
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
    }
}
