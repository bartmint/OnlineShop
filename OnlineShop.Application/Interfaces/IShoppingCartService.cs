﻿using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShoppingCartService
    {
        void AddToCart(int id);
        //ShoppingCartItem Show();
    }
}
