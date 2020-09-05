using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductsListRepository : ICommonProductsRepo
    {
       Task<IEnumerable<Product>> GetProducts();
        //Task<IEnumerable<Product>> GetProductsSorted(string category, IQueryable<Product> products);
    }
}
