using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using OnlineShop.Infrastructure.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductManagerRepository :CommonGetProductsRepository ,IProductManager
    {

        public ProductManagerRepository(ApplicationDb ctx):base(ctx)
        { }
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
        public async Task<int> UpdateProduct(Product product)//zmiana na asynchroniczne pozwolilo na pozbycie sie bledu kiedy chcialem dwa razy
                                                             //edytowac produkt, wywalalo blad ze korzysta podwojnie z db context
        {
            _ctx.Products.Update(product);
            await _ctx.SaveChangesAsync();
            return product.Id;
        }
    }
}
