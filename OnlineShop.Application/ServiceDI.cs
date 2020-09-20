using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Components;
using OnlineShop.Application.ComponentsAbstract;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Domain.Interfaces;
using System.Net.Http;
using System.Reflection;

namespace OnlineShop.Infrastructure
{
    public static class ServiceDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductManagerService, ProductManagerService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IProductsListService, ProductsListService>();
            
            services.AddTransient<ICheckoutService, CheckoutService>();

            //components view
            services.AddTransient<InvokeCart, ShoppingCart>();
            services.AddTransient<InvokeCategories, CategoryMenu>();

            //autoampper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //validation
            //services.AddTransient<IValidator<FileValidator>, IFormFile>();
            services.AddTransient<IValidator<NewProductVM>, NewProductValidation>();
            return services;
        }
    }
}
