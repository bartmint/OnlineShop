using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Enums.ProductItems;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.ViewModels.Product
{
    public class AddProductVM:ProductVM
    {
        public List<IFormFile> Images { get; set; }
    }
}
