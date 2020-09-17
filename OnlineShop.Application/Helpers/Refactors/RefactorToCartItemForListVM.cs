using OnlineShop.Application.ViewModels.CartItems;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Helpers.Refactors
{
    public static class RefactorToCartItemForListVM
    {
        public static List<CartItemForListVm> RefactorFrom(List<ShoppingCartItem> items)
        {
            List<CartItemForListVm> model = new List<CartItemForListVm>();
            foreach (var item in items)
            {
                CartItemForListVm cart = new CartItemForListVm();
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
