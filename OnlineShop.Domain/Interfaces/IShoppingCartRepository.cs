using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task AddToCart(Product product, int quantity);
        Task<int> RemoveFromCart(Product product);
        IQueryable<ShoppingCartItem> GetShoppingCartItems();
        Task ClearCart();
        Task<decimal> GetShoppingCartTotal();
        Task<int> GetShoppingCartAmmount();
    }
}
