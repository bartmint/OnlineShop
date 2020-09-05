using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Infrastructure.Repositories.Common
{
    public class CommonGetProductsRepository
    {
        public readonly ApplicationDb _ctx;

        public CommonGetProductsRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }
        public Product GetProductById(int Id)
        {
            Product product = _ctx.Products.Include(x => x.Paths).Include(q => q.Ammount).FirstOrDefault(p => p.Id == Id);
            return product;
        }
    }
}
