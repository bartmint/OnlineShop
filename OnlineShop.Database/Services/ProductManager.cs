using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Services
{
    public class ProductManager : IProductManager
    {
        //private readonly ApplicationDb _db;
        //public ProductManager(ApplicationDb db)
        //{
        //    _db = db;
        //}
        public Task<int> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> ProductsQ()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
