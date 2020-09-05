using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task AddToCart(Product product, int quantity);
        Task<int> RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        Task ClearCart();
        decimal GetShoppingCartTotal();
    }
}
