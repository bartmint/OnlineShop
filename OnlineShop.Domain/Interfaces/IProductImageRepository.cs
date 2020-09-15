using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductImageRepository
    {
        List<string> AddPathToPhoto(List<IFormFile> images);
        Task RemoveItems(int id);

    }
}
