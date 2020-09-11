﻿using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductsListService
    {
       Task<IEnumerable<Product>> GetProducts();
        Product GetProductById(int id);
    }
}
