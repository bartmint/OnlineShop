using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductImageRepository
    {
        List<string> AddPathToPhoto(List<IFormFile> images);
        void RemoveItems(int id);

    }
}
