using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductManager _productManager;
        private readonly ISessionSettings _session;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductManager productManager, ISessionSettings session)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productManager = productManager;
            _session = session;
            //_session.OnGet();
            
        }
        public void  AddToCart(int id)
        {
            int quantity = 1;
            var selectedProduct = _productManager.GetProductById(id);
             _shoppingCartRepository.AddToCart(selectedProduct, quantity);
        }
       
    }
}
