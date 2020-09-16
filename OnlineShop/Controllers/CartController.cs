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

        public CartController(IShoppingCartService shoppingCartService)=> _shoppingCartService = shoppingCartService;
        
        public IActionResult Index()
        {
            var model = _shoppingCartService.GetShoppingCartItems();
            if (model.CartItems.Count != 0)
            {
                return View(model);
            }
            ViewBag.Cart = "Your Cart is empty";
            return View();
        }
        public  IActionResult AddToShoppingCart(int? Id)
        {
            if (Id.HasValue)
            {
                _shoppingCartService.AddToCart(Id.Value);
                //return RedirectToAction("Index","Home");//zmienic na liste produktow
                return RedirectToAction("Index");
            }
            return Json("Add to shopping cart -> failed");
            
        }
        public IActionResult RemoveFromCart(int? Id)
        {
            if (Id.HasValue)
            {
                _shoppingCartService.RemoveFromCart(Id.Value);
                return RedirectToAction("Index");
            }
            return Json("RemoveFromShoppingCart -> failed");
        }
        public IActionResult ClearShoppingCart()
        {
            _shoppingCartService.ClearCart();
            return RedirectToAction("ListOfProducts","Products");
        }
        
    }
}
