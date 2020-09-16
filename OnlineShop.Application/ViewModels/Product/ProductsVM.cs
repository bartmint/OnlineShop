using System;
using System.Collections.Generic;
using System.Text;
namespace OnlineShop.Application.ViewModels.Product
{
    public class ProductsVM
    {
        public List<ProductVM> Products { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

    }
}
