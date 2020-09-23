using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.CartItems;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShoppingCartService
    {
        Task AddToCart(int id);
        Task<int> RemoveFromCart(int id);
        Task<ListCartItemsVM> GetShoppingCartItems();
        Task ClearCart();
        Task<decimal> GetShoppingCartTotal();
    }
}
