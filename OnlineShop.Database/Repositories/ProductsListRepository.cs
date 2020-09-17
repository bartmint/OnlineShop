using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Enums.ProductItems;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using OnlineShop.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductsListRepository : CommonGetProductsRepository, IProductsListRepository
    {
        public ProductsListRepository(ApplicationDb ctx) : base(ctx) { }
        public IQueryable<Product> GetProducts()
        {
            return  _ctx.Products;
        }
    }
}
