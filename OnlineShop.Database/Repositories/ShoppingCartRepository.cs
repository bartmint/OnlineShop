using Microsoft.AspNetCore.Http;
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

        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public ShoppingCartRepository(ApplicationDb ctx, ISessionSettings session)
        {
            _ctx = ctx;
            _session = session;
        }
        public void AddToCart(Product product,int id)
        {
            //setting Id
            ShoppingCartId = _session.OnGet();

            //retrieve product from database
            //ShoppingCartId = GetCartId();

            var cartItem = _ctx.CartItems.FirstOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);
            //create new product if no cart item exists
            if (cartItem == null)
            {
                cartItem = new ShoppingCartItem
                {
                    ProductId=id,
                    CartId=ShoppingCartId,
                    Product=_ctx.Products.SingleOrDefault(p=>p.Id==id),
                    Quantity=1,
                };
                _ctx.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _ctx.SaveChanges();
        }
        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        
        
    }
}
