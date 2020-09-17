using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ComponentsAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.UI.Components
{
    public class Categories
    {
        private readonly InvokeCategories _categories;

        public Categories(InvokeCategories categories)
        {
            _categories = categories;
        }
        public IViewComponentResult Invoke()
        {
            return _categories.Invoke();
        }
    }
}
