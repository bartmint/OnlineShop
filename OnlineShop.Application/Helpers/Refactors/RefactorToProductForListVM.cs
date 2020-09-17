using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Helpers.Refactors
{
    public static class RefactorToProductForListVM
    {
        public static List<ProductForListVM> RefactorFrom(List<Product> items)
        {
            List<ProductForListVM> model = new List<ProductForListVM>();
            foreach (var item in items)
            {
                ProductForListVM product = new ProductForListVM();
                product.ProductId = item.Id;
                product.Model = item.Model;
                product.Producent = item.ProductionCompany.ToString();
                product.Value = item.Value;
                product.PathToImage = "~/Images/"+item.Paths[0].Path;
                model.Add(product);
            }
            return model;
        }
    }
}
