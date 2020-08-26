using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public List<ShoppingCartItem> shoppingCartItems { get; set; }
        public static ShoppingCartRepository GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;//mozna tez wstrzyknac gotowy obiekt session przez konstruktor 
            var context = service.GetService<ApplicationDb>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCartRepository(context) { ShoppingCartId=cartId };

        }
        public void AddToCart(Product product, int quantity)
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
                _ctx.CartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _ctx.SaveChanges();
        }

        public void ClearCart()
        {
             var cartItems = _ctx
                .CartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId);
            _ctx.CartItems.RemoveRange(cartItems);

            _ctx.SaveChanges();
        }

        public Product FindProduct(int productId)
        {
            return _ctx.Products.FirstOrDefault
                (p => p.Id == productId);
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ??
               (shoppingCartItems =
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

        public int RemoveFromCart(Product product)
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

            _ctx.SaveChanges();
            return localAmount;
        }
    }
}
