using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductManagerService
    {
        Task<int> AddProduct(AddProductViewModel model);
        Task<int> UpdateProduct(EditProductViewModel product);
        void RemoveItem(int id);
    }
}
