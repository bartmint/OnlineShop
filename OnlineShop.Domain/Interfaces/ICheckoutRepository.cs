using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICheckoutRepository
    {
        Task CreateOrder(Order order, List<ShoppingCartItem> shoppingCartItems);
    }
}
