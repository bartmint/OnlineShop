using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShoppingCartService
    {
        void AddToCart(int id);
        int RemoveFromCart(int id);
        CartItemsVM GetShoppingCartItems();
        Task ClearCart();
        decimal GetShoppingCartTotal();
    }
}
