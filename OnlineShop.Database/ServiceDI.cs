using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Infrastructure.Utilities;
using System;

namespace OnlineShop.Infrastructure
{
    public static class ServiceDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductManager, ProductManagerRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAmmountRepository, AmmountRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IProductsListRepository, ProductsListRepository>();
            services.AddTransient<ICheckoutRepository, CheckoutRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();



            services.AddScoped<ISessionSettings, SessionSettings>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "Cart";
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });
           
            return services;
        }
    }
}
