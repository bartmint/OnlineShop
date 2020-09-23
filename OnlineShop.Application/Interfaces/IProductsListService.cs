using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductsListService
    {
        ListProductsVM GetProducts(string sortOrder, string searchString, int? pageNumber, string category);
       Product GetProductById(int id);
    }
}
