using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product, int quantity);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        Product FindProduct(int productId);
    }
}
