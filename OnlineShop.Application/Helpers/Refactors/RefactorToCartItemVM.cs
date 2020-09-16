using OnlineShop.Application.ViewModels.CartItems;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Helpers.Refactors
{
    public static class RefactorToCartItemVM
    {
        public static List<CartItemForVm> RefactorFrom(List<ShoppingCartItem> items)
        {
            List<CartItemForVm> model = new List<CartItemForVm>();
            foreach (var item in items)
            {
                CartItemForVm cart = new CartItemForVm();
                cart.ProductId = item.ProductId;
                cart.Model = item.Product.Model;
                cart.QuantityInCart = item.Quantity;
                cart.TotalProductQuantity = item.Product.Ammount.Quantity;
                cart.Value = item.Product.Value;
                model.Add(cart);
            }
            return model;
        }
    }
}
