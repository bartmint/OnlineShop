using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShoppingCartService
    {
        Task AddToCart(int id);
    }
}
