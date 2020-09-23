using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.CartItems;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Enums.ProductItems;
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
        private readonly IMapper _mapper;

        public ProductsListService(IProductsListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ListProductsVM GetProducts(string sortOrder, string searchString, int? pageNumber, string category)
        {
            const int pageSize = 2;
            var items = _repository.GetProducts().Include(e=>e.Paths).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Model.Contains(searchString));
            }
            
            if (!String.IsNullOrEmpty(category))
            {
                foreach (var prod in (Producent[])Enum.GetValues(typeof(Producent)))
                {
                    if (category == prod.ToString())
                        items = items.Where(p => p.ProductionCompany == prod);
                }
            }

            Paginate paginate = new Paginate(items.Count(),pageNumber.Value,pageSize);

            items = items.Skip(pageSize * (pageNumber.Value - 1)).Take(pageSize);

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
                    string searched = String.IsNullOrEmpty(searchString) ? category : searchString;
                    paginate.Error= $"Sorry, we cant find product:     {searched}";
                    break;
            }

            ListProductsVM testPaginationVM = new ListProductsVM();
            testPaginationVM.Paginate = paginate;
            testPaginationVM.Products = (items.ProjectTo<ProductForListVM>(_mapper.ConfigurationProvider)).ToList();

            testPaginationVM.Count = items.Count();

            return testPaginationVM;
        }
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
    }
}
