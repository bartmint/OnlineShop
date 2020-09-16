using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class ListCartItemsForVM
    {
        public List<CartItemForVm> CartItems { get; set; }
        public decimal ShoppingCartTotalPayment { get; set; }
        public int TotalCartItems { get; set; }
    }
}
