using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using OnlineShop.Domain.Models;
using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.CartItems;
using AutoMapper;
using OnlineShop.Application.Helpers.Refactors;

namespace OnlineShop.Application.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductManager _productManager;

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

        public ListCartItemsVM GetShoppingCartItems()
        {
            ListCartItemsVM model = new ListCartItemsVM();
            model.ShoppingCartTotalPayment = _shoppingCartRepository.GetShoppingCartTotal();
            model.CartItems = RefactorToCartItemForListVM.RefactorFrom(_shoppingCartRepository.GetShoppingCartItems());
            model.TotalCartItems = model.CartItems.Count;

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
