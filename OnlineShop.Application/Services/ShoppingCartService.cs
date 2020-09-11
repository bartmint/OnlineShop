using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using OnlineShop.Domain.Models;
using OnlineShop.Application.ViewModels;

namespace OnlineShop.Application.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductManager _productManager;
        private readonly ISessionSettings _session;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductManager productManager)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productManager = productManager;
            
        }
        public void AddToCart(int id)
        {
            int quantity = 1;
            var selectedProduct = _productManager.GetProductById(id);
             _shoppingCartRepository.AddToCart(selectedProduct, quantity);
        }

        public async Task ClearCart()
        {
           await _shoppingCartRepository.ClearCart();
        }

        public CartItemsViewModel GetShoppingCartItems()
        {
            CartItemsViewModel model = new CartItemsViewModel()
            {
                CartItems = new List<ShoppingCartItem>(),
                ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal()
            };
            var list= _shoppingCartRepository.GetShoppingCartItems();
            model.CartItems = list;
            return model;
        }

        public decimal GetShoppingCartTotal()
        {
            return _shoppingCartRepository.GetShoppingCartTotal();
        }

        public int RemoveFromCart(int id)
        {
            var selectedProduct = _productManager.GetProductById(id);
            return _shoppingCartRepository.RemoveFromCart(selectedProduct);
        }

       
    }
}
