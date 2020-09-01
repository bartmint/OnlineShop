using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductManagerRepository : IProductManager
    {
        private readonly ApplicationDb _ctx;

        public ProductManagerRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> CreateProduct(Product product)
        {
            await _ctx.Products.AddAsync(product);
            await _ctx.SaveChangesAsync();
            return product.Id;
        }

        public int DeleteProduct(int id)
        {
            var entity = _ctx.Products.FirstOrDefault(p => p.Id == id);
            _ctx.Products.Remove(entity);
            return _ctx.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products.Include(x => x.Paths).Include(q=>q.Ammount).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> ProductsE()
        {
            return _ctx.Products.Include(x => x.Paths);
        }

        public int UpdateProduct(Product product)
        {
            _ctx.Products.Update(product);
            return _ctx.SaveChanges();
        }
    }
}
