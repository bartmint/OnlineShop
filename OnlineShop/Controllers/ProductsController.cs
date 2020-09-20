using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System;

namespace OnlineShop.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsListService _productsListService;

        public ProductsController(IProductsListService productsListService)
        {
            _productsListService = productsListService;
        }
        
        public IActionResult Index(int? pageNumber, string sortOrder, string searchString,string currentFilter, string category)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["YearProductionSortParm"] = sortOrder == "Rok produkcji" ? "year_desc" : "Rok produkcji";
            ViewData["currentSearch"] = searchString; //obsluguje pole wyszukiwania
            ViewData["currentSort"] = sortOrder;//obsluguje filtry

            ViewData["CurrentFilter"] = searchString;

            var model = _productsListService.GetProducts(sortOrder, searchString, pageNumber ?? 1, currentFilter, category);
            return View(model);        
        }
        public IActionResult ProductDetails(int? id)
        {
            var model = _productsListService.GetProductById(id.Value);
            if (model != null)
            {
                return View(model);
            }
            //Response.StatusCode = 404;
            //return View("ProductNotFound", id.Value);
            return View();
        }
    }
}
