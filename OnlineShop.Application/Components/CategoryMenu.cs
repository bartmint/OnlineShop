using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ComponentsAbstract;
using OnlineShop.Domain.Enums.ProductItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Application.Components
{
    public class CategoryMenu:ViewComponent, InvokeCategories
    {
        //sortowanie po nazwach
        public IViewComponentResult Invoke()
        {
            var categories = Enum.GetValues(typeof(Producent))
                .Cast<Producent>()
                .Select(c => (c))
                .ToList();
            return View(categories);
        }
    }
}
