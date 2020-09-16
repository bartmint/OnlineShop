using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class CartItemForVm
    {
        public int ProductId { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public int TotalProductQuantity { get; set; }
        public int QuantityInCart { get; set; }
        

    }
}
