﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
