using OnlineShop.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.Product
{
    public class ListProductsVM
    {
        public List<ProductForListVM> Products { get; set; }
        public Paginate Paginate { get; set; }
        public int Count { get; set; }
    }
}
