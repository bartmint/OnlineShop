using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.DAL;
using System;

namespace OnlineShop.Infrastructure.Repositories
{
    public static class CartSession
    {
        public static string GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CartId", cartId);

            return cartId;
        }
    }
}
