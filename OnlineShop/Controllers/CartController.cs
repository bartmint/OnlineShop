﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.UI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartController(IShoppingCartService shoppingCartService)=> _shoppingCartService = shoppingCartService;
        
        public async Task<IActionResult> Index()
        {
            var model =await _shoppingCartService.GetShoppingCartItems();
            if (model.CartItems.Count != 0)
            {
                return View(model);
            }
            ViewBag.Cart = "Your Cart is empty";
            return View();
        }
        public async Task<IActionResult> AddToShoppingCart(int? id)
        {
            if (id.HasValue)
            {
                await _shoppingCartService.AddToCart(id.Value);
                //return RedirectToAction("Index","Home");//zmienic na liste produktow
                return RedirectToAction("Index");
            }
            return Json("Add to shopping cart -> failed");
            
        }
        public async Task<IActionResult> RemoveFromCart(int? Id)//pozmieniac na male id
        {
            if (Id.HasValue)
            {
                await _shoppingCartService.RemoveFromCart(Id.Value);
                return RedirectToAction("Index");
            }
            return Json("RemoveFromShoppingCart -> failed");
        }
        public async Task<IActionResult> ClearShoppingCart()
        {
            await _shoppingCartService.ClearCart();
            return RedirectToAction("Index","Products");
        }
      
    }
}
