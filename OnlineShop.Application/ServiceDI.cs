using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure
{
    public static class ServiceDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductManagerService, ProductManagerService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            return services;
        }
    }
}
