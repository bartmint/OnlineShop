using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Application.ViewModels;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Interfaces;
using OnlineShop.UI.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdministrationController : Controller
    {
        private readonly IProductManagerService _productManagerService;

        public AdministrationController(IProductManagerService productManagerService)
        {
            _productManagerService = productManagerService;
        }
        [Route("Administration/ManageProducts")]
        [HttpGet]
        public IActionResult Index(int? pageNumber, string searchString,string currentFilter)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var model = _productManagerService.GetProducts(pageNumber ?? 1, searchString);
            return View(model);
        }
        [Route("Administration/ManageOrders")]
        [HttpGet]
        public IActionResult Orders(int? pageNumber, string searchString, string currentFilter)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var model = _productManagerService.GetProducts(pageNumber ?? 1, searchString);
            //return View(model);
            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(NewProductVM product)
        {
            if (ModelState.IsValid)
            {
               int id = await _productManagerService.AddProduct(product);
               return RedirectToAction("ProductDetails", "Products", new {Id=id });//same id bez new powoduje blad w photo null
            }
            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public IActionResult UpdateProduct(int? id)//musi byc id bo przy kliknieciu przycisku update zwraca wartosc is invalid ''
        {
            var model = _productManagerService.GetProduct(id.Value);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(NewProductVM product)
        {
            if (ModelState.IsValid)
            {
                int id = await _productManagerService.UpdateProduct(product);
                return RedirectToAction("ProductDetails", "Products", new { Id=id });//narazie przekierowanie na index, bo na details powoduje nulla przy zdjeciach
            }
            return View();
        }
        [HttpGet]
        public   IActionResult RemoveItem(int? id)
        {
            if (id == null)
            {
                return View();
            }
             _productManagerService.RemoveItem(id.Value);
            return RedirectToAction("Index", "Home");
        }
    }
}
