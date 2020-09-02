using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Repositories
{
    public static  class CartSessionRepository
    {
        
        public static ShoppingCartRepository GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = service.GetService<ApplicationDb>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }
    }
}
