﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Application.ViewModels;
using OnlineShop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManagerService _productManagerService;

        public HomeController(IProductManagerService productManagerService)
        {
            _productManagerService = productManagerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       // [Route("Szczegoly/{id}")] dziala
        public IActionResult Details(int id)
        {
            var model = _productManagerService.GetProduct(id);
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
    }
}
