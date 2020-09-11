using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;

namespace OnlineShop.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsListService _productsListService;

        public ProductsController(IProductsListService productsListService)
        {
            _productsListService = productsListService;
        }
        public IActionResult ProductDetails(int? id)
        {
            var model = _productsListService.GetProductById(id.Value);
            if (model != null)
            {
                return View(model);
            }
            return NotFound(404);
        }
        public IActionResult ListOfProducts() 
        {
            var products = _productsListService.GetProducts();
            return View(products);
        }
    }
}
