using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product, int quantity);
        int RemoveFromCart(Product product);
        IQueryable<ShoppingCartItem> GetShoppingCartItems();
        Task ClearCart();
        decimal GetShoppingCartTotal();
        Task<int> GetShoppingCartAmmount();
    }
}
