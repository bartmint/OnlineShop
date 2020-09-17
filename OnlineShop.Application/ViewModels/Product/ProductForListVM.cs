using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.Product
{
    public class ProductForListVM
    {
        public int ProductId { get; set; }
        public string Producent { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public string PathToImage { get; set; }

    }
}
