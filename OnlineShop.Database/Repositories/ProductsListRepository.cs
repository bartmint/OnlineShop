using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Enums.ProductItems;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using OnlineShop.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductsListRepository : CommonGetProductsRepository, IProductsListRepository
    {
        public ProductsListRepository(ApplicationDb ctx) : base(ctx) { }
        //public async Task<IEnumerable<Product>> GetProducts()
        //{
        //    return await _ctx.Products.Include(p => p.Paths).Include(a => a.Ammount).Take(5).ToListAsync();
        //}
        public IQueryable<Product> GetProducts()
        {
            return  _ctx.Products;
        }

        /* public Task<IEnumerable<Product>> GetProductsSorted(string category, IQueryable<Product> products)
         {
             string _category = category;
             string currentCategory = string.Empty;

             if (string.IsNullOrEmpty(_category))//jesli uzytkownik nie filtruje produktow przez ich kategorie
             {
                 products = products
                     .OrderBy(p => p.Id)
                     .Take(6);
                 currentCategory = "All products";
             }

             else//jesli uzytkownik filtruje produkty poprzez ich kategorie(dorobic reszte kategorii), do naprawy cos nie smiga
             {
                 if (string.Equals("Dell", _category, StringComparison.OrdinalIgnoreCase))
                 {
                     products = products.Where(p => p.ProductionCompany.Equals((Producent)0));
                 }
                 else if (string.Equals("Asus", _category, StringComparison.OrdinalIgnoreCase))
                 {
                     products = products.Where(p => p.ProductionCompany.Equals((Producent)1));
                 }
                 else if (string.Equals("Lenovo", _category, StringComparison.OrdinalIgnoreCase))
                 {
                     products = products.Where(p => p.ProductionCompany.Equals((Producent)2));
                 }
                 else if (string.Equals("Hp", _category, StringComparison.OrdinalIgnoreCase))
                 {
                     products = products.Where(p => p.ProductionCompany.Equals((Producent)3));
                 }
                 else if (string.Equals("Macbook", _category, StringComparison.OrdinalIgnoreCase))
                 {
                     products = products.Where(p => p.ProductionCompany.Equals((Producent)4));
                 }

                 currentCategory = _category;
             }

             var model = new ProductsListViewModel
             {
                 Products = products,
                 category = category
             };
             return (model);
         }*/
    }
}
