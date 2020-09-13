using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.UI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Order(Order order)
        {
            if (ModelState.IsValid)
            {
                bool check = await _checkoutService.CreateOrder(order);

                if (!check)
                {
                    ModelState.AddModelError("", "your cart is empty");
                    return View();
                }
                return RedirectToAction("OrderComplete");
            }
            return View(order);
        }
        public IActionResult OrderComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order";
            return View();
        }
    }
}
