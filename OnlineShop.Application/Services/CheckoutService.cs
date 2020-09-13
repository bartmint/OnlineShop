using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CheckoutService:ICheckoutService
    {
        private readonly ICheckoutRepository _checkout;
        private readonly IShoppingCartRepository _shoppingCart;

        public CheckoutService(ICheckoutRepository checkout, IShoppingCartRepository shoppingCart)
        {
            _checkout = checkout;
            _shoppingCart = shoppingCart;
        }
        public async Task<bool> CreateOrder(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            if (items.Count != 0)
            {
                await _checkout.CreateOrder(order, items);
                await _shoppingCart.ClearCart();
                return true;
            }
            return false;
        }

    }
}
