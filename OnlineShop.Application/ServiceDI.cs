using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Components;
using OnlineShop.Application.ComponentsAbstract;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Interfaces;
using System.Net.Http;

namespace OnlineShop.Infrastructure
{
    public static class ServiceDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductManagerService, ProductManagerService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IProductsListService, ProductsListService>();
            services.AddTransient<InvokeCart, ShoppingCart>();
            services.AddTransient<InvokeCategories, CategoryMenu>();
            services.AddTransient<ICheckoutService, CheckoutService>();
            return services;
        }
    }
}
