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
    public class AdministrationController : Controller
    {
        private readonly IProductManagerService _productManagerService;

        public AdministrationController(IProductManagerService productManagerService)
        {
            _productManagerService = productManagerService;
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel product)
        {
            if (ModelState.IsValid)
            {
               int id = await _productManagerService.AddProduct(product);
               return RedirectToAction("Details", "Home", new {Id=id });//same id bez new powoduje blad w photo null
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)//musi byc id bo przy kliknieciu przycisku update zwraca wartosc is invalid ''
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(EditProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                int id = _productManagerService.UpdateProduct(product);
                //return RedirectToAction("Details", "Home", id );
                return RedirectToAction("Details", "Home", new { Id = id });//narazie przekierowanie na index, bo na details powoduje nulla przy zdjeciach
            }
            return View();
        }
        [HttpGet]
        public   IActionResult RemoveItem(int id)
        {
             _productManagerService.RemoveItem(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
