using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public async Task<IActionResult> AddToShoppingCart(int Id)
        {
            if (Id!=0) 
            {
                await _shoppingCartService.AddToCart(Id);
            }
            return RedirectToAction("CartRepository");
        }
    }
}
