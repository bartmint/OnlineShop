using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class UpdateProductViewModel
    {
        public List<IFormFile> Images;
        public UpdateProductViewModel()
        {
            Images = new List<IFormFile>();
        }
        
    }
}
