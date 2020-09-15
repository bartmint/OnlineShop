using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductManagerService
    {
        Task<int> AddProduct(AddProductVM model);
        Task<int> UpdateProduct(EditProductVM product);
        void RemoveItem(int id);
    }
}
