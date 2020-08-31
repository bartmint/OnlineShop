using Microsoft.AspNetCore.Hosting;
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
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPut]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                int id=await _productManagerService.CreateProduct(product);
                return RedirectToAction("Details", "Home", new { Id = id });
            }
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return Json(allErrors);
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
            return Json("not found");

        }
    }
}
