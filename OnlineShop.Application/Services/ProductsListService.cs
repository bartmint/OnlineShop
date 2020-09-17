using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Helpers.Refactors;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.CartItems;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
   public  class ProductsListService:IProductsListService
    {
        private readonly IProductsListRepository _repository;

        public ProductsListService(IProductsListRepository repository)
        {
            _repository = repository;
        }

        public ListProductsVM GetProducts(string sortOrder, string searchString, int? pageNumber, string currentFilter, string category)
        {
            const int pageSize = 5;
            var items = _repository.GetProducts();
            if (!String.IsNullOrEmpty(searchString))
            {
                pageNumber=1;
                items = items.Where(s => s.Model.Contains(searchString)).Include(e => e.Paths);
            }
            else
            {
                searchString = currentFilter;
            }

            Paginate paginate = new Paginate(items.Count(),pageNumber.Value,pageSize);
            paginate.SearchString = searchString;

            items = items.Skip(pageSize * (pageNumber.Value - 1)).Include(e=>e.Paths).Take(pageSize);//zmienic wyzej to ListAsync na ToList()

            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(s => s.ProductionCompany);
                    break;
                case "Price":
                    items = items.OrderBy(p => p.Value);
                    break;
                case "price_desc":
                    items = items.OrderByDescending(s => s.Value);
                    break;
                case "Rok produkcji":
                    items = items.OrderBy(s => s.ProductionYear);
                    break;
                case "year_desc":
                    items = items.OrderByDescending(s => s.ProductionYear);
                    break;
                default:
                    items = items.OrderBy(s => s.Id);
                    paginate.Error= $"Sorry, we cant find product:     {searchString}";
                    break;
            }

            ListProductsVM testPaginationVM = new ListProductsVM();
            testPaginationVM.Paginate = paginate;
            testPaginationVM.Products = RefactorToProductForListVM.RefactorFrom(items.ToList());
            testPaginationVM.Count = items.Count();

            return testPaginationVM;
        }
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
    }
}


//var productsList = new ListProductsVM()
//{
//    PageSize = pageSize,
//    CurrentPage = pageNumber.Value,
//    SearchString = searchString,
//    Products = RefactorToProductForListVM.RefactorFrom(productsToShow),
//    Count = productsToShow.Count
//};