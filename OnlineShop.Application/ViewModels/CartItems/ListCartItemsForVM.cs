using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class ListCartItemsForVM
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
