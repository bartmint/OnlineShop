using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels
{
    public class CartItemsVM
    {
        public CartItemsVM()
        {
            CartItems = new List<ShoppingCartItem>();
        }
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
