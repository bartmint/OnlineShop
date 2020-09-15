using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Enums.ProductItems;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.ViewModels.Product
{
    public class EditProductVM:ProductVM
    {
        public int Id { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
