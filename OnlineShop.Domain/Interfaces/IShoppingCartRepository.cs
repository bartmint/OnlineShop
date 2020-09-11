using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product, int quantity);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        Task ClearCart();
        decimal GetShoppingCartTotal();
    }
}
