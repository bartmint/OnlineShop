using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public  IActionResult AddToShoppingCart(int Id)
        {
            _shoppingCartService.AddToCart(Id);
            return Json(HttpContext.Session.GetString("_Cart"));

            if (Id != 0)
            {
                 _shoppingCartService.AddToCart(Id);
            }
            var stringObj = HttpContext.Session.GetString("Cart");
            //_shoppingCartService.Show();
            return RedirectToAction("CartRepository");
        }
       

    }
}
