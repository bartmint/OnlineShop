using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductsListService
    {
       Task<List<Product>> GetProducts(int pageSize, int pageNumber, string searchString, string sortOrder, string currentFilter);
       Product GetProductById(int id);
    }
}
