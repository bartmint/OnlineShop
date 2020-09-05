using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductManager:ICommonProductsRepo
    {
        Task<int> CreateProduct(Product product);
        int DeleteProduct(int id);
        Task<int> UpdateProduct(Product product);

    }
}
