using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.Infrastructure
{
    public static class ServiceDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductManager, ProductManagerRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAmmountRepository, AmmountRepository>();
            services.AddScoped(sp => CartSessionRepository.GetCart(sp));
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            return services;
        }
    }
}
