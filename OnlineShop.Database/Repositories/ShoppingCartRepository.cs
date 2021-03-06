﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ShoppingCartRepository:IShoppingCartRepository
    {
        private readonly ApplicationDb _ctx;
        private readonly ISessionSettings _session;
        private string ShoppingCartId { get; set; }
        public IQueryable<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCartRepository(ApplicationDb ctx, ISessionSettings session)
        {
            _ctx = ctx;
            _session = session;
            ShoppingCartId = _session.OnGet();
        }

        public async Task  AddToCart(Product product, int quantity)
        {
            //setting Id

            //retrieve product from database
            //ShoppingCartId = GetCartId();

            var cartItems = await
                _ctx.CartItems.FirstOrDefaultAsync(
                c => c.Product.Id == product.Id
                && c.CartId == ShoppingCartId);
            //create new product if no cart item exists
            if (cartItems == null)
            {
                cartItems = new ShoppingCartItem
                {
                    CartId= ShoppingCartId,
                    Product=product,
                    Quantity=quantity,
                };
                _ctx.CartItems.Add(cartItems);
            }
            else
            {
                cartItems.Quantity++;
            }
            await _ctx.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public async Task<int> RemoveFromCart(Product product)
        {
            var shoppingCartItem =await
                _ctx.CartItems.SingleOrDefaultAsync(
                    s => s.Product.Id == product.Id
                    && s.CartId == _session.OnGet());
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

        public IQueryable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (
                ShoppingCartItems =
                _ctx.CartItems
                .Where(c => c.CartId == _session.OnGet())
                .Include(s => s.Product)
                .ThenInclude(p => p.Paths)
                .Include(a => a.Product.Ammount));
                 
        }

        public async Task ClearCart()
        {
            var cartItems = _ctx
                .CartItems
                .Where(s => s.CartId == ShoppingCartId);
            _ctx.CartItems.RemoveRange(cartItems);

           await _ctx.SaveChangesAsync();
        }

        public async Task<decimal> GetShoppingCartTotal()
        {
            var total =await _ctx.CartItems
                .Where(s => s.CartId == ShoppingCartId)
                .Select(s => s.Product.Value * s.Quantity).SumAsync();
            return total;
        }
        public async Task<int> GetShoppingCartAmmount()
        {
            var total = await _ctx.CartItems.Where(s => s.CartId == ShoppingCartId).CountAsync();
            return total;
        }
    }
}
