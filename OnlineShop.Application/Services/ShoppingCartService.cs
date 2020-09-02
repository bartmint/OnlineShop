using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task AddToCart(int productId)
        {
            int quantity = 1;
            var selectedProduct = _productManager.GetProductById(productId);
            await _shoppingCartRepository.AddToCart(selectedProduct, quantity);
        }
    }
}
