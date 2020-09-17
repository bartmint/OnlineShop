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
        
        public IActionResult Index(int? pageNumber, string sortOrder, string searchString,string currentFilter, string category)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["YearProductionSortParm"] = sortOrder == "Rok produkcji" ? "year_desc" : "Rok produkcji";
            ViewData["currentSearch"] = searchString; //obsluguje pole wyszukiwania
            ViewData["currentSort"] = sortOrder;//obsluguje filtry
            //to mozna przeniesc do serwisu
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }

            var model = _productsListService.GetProducts(sortOrder, searchString, pageNumber.Value, currentFilter, category);
            return View(model);        
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
    }
}
