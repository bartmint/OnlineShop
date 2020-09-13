using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ComponentsAbstract
{
    public interface IShoppingCart
    {
        IViewComponentResult Invoke();
    }
}
