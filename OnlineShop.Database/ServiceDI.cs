using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IProductsListRepository, ProductsListRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => CartSessionRepository.GetCart(sp));//<- tutaj
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "Cart";
            });
           
            //nie tworzy ciasteczka na stronie, czemu? update** tworzy ciasteczko ale AddScoped<> nie dziala, ciasteczko tworzyc trzeba recznie w kontrolerze
            return services;
        }
    }
}
