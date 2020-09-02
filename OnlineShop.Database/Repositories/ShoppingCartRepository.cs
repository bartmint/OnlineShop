using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDb _ctx;
        public ShoppingCartRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public async Task AddToCart(Product product, int quantity)
        {
            var shoppingCartItem =
                _ctx.CartItems.SingleOrDefault(
                    s => s.Product.Id == product.Id
                    && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = quantity
                };
                await _ctx.CartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
           await _ctx.SaveChangesAsync();
        }

        public async Task ClearCart()
        {
            var cartItems = _ctx
               .CartItems
               .Where(s => s.ShoppingCartId == ShoppingCartId);
            _ctx.CartItems.RemoveRange(cartItems);

            await _ctx.SaveChangesAsync();
        }

        public Product FindProduct(int productId)
        {
            return _ctx.Products.FirstOrDefault
                (p => p.Id == productId);
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
               (ShoppingCartItems =
               _ctx.CartItems
               .Where(c => c.ShoppingCartId == ShoppingCartId)
               .Include(s => s.Product)
               .ToList()
               );
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _ctx.CartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Product.Value * s.Quantity).Sum();
            return total;
        }

        public async Task<int> RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                _ctx.CartItems.SingleOrDefault(
                    s => s.Product.Id == product.Id
                    && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _ctx.CartItems.Remove(shoppingCartItem);
                }

            }

            await _ctx.SaveChangesAsync();
            return localAmount;
        }
    }
}
