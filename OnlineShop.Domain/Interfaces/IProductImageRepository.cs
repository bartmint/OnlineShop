using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductImageRepository
    {
        List<string> AddPathToPhoto(List<IFormFile> images);

    }
}
