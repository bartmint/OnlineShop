using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICommonProductsRepo
    {
        Product GetProductById(int id);
    }
}
