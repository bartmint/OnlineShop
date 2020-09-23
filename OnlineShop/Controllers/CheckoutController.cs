using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.UI.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Order order)
        {
            if (ModelState.IsValid)
            {
                bool check = await _checkoutService.CreateOrder(order);

                if (!check)
                {
                    ViewBag.ErrorEmptyCart = "Your cart is empty, u cant order empty cart";
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
