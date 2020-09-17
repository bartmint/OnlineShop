using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class ListCartItemsVM
    {
        public List<CartItemForListVm> CartItems { get; set; }
        public decimal ShoppingCartTotalPayment { get; set; }
        public int TotalCartItems { get; set; }
    }
}
