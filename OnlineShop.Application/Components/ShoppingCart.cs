using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ComponentsAbstract;
using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Components
{
    public class ShoppingCart:ViewComponent, IShoppingCart
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCart(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IViewComponentResult Invoke()
        {
            var ammount = _shoppingCartRepository.GetShoppingCartAmmount();
            return View(ammount.Result);
        }
    }
}
