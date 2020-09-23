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
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace OnlineShop.Application.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        private readonly IAmmountRepository _ammountRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductManager productManager, IMapper mapper, IAmmountRepository ammountRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productManager = productManager;
            _mapper = mapper;
            _ammountRepository = ammountRepository;
        }
        public async Task AddToCart(int id)
        {
            int quantity = 1;
            var selectedProduct = _productManager.GetProductById(id);
            await _ammountRepository.RemoveOne(id);
            await _shoppingCartRepository.AddToCart(selectedProduct, quantity);
        }

        public async Task ClearCart()
        {
           await _shoppingCartRepository.ClearCart();
        }

        public async Task<ListCartItemsVM> GetShoppingCartItems()
        {
            ListCartItemsVM model = new ListCartItemsVM();
           
            model.CartItems = (_shoppingCartRepository.GetShoppingCartItems().ProjectTo<CartItemForListVm>(_mapper.ConfigurationProvider)).ToList();
            model.ShoppingCartTotalPayment =await _shoppingCartRepository.GetShoppingCartTotal();
            model.TotalCartItems = model.CartItems.Count;

            return model;
        }

        public async Task<decimal> GetShoppingCartTotal()
        {
            return await _shoppingCartRepository.GetShoppingCartTotal();
        }

        public async Task<int> RemoveFromCart(int id)
        {
            var selectedProduct = _productManager.GetProductById(id);
            return await _shoppingCartRepository.RemoveFromCart(selectedProduct);
        }

       
    }
}
