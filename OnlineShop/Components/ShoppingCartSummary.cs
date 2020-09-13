using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OnlineShop.Application.ComponentsAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.UI.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly IShoppingCart _cart;

        public ShoppingCartSummary(IShoppingCart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return _cart.Invoke();
        }
    }
}
