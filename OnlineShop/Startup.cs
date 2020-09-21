using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.DAL;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDb>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));
            services.AddDefaultIdentity<UserData>(options =>
           {
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = true;
               options.Password.RequireDigit = true;
               options.SignIn.RequireConfirmedEmail = false;
           })
                .AddEntityFrameworkStores<ApplicationDb>();

            services.AddApplication();
            //services.AddControllersWithViews().AddFluentValidation(fv=>fv.RunDefaultMvcValidationAfterFluentValidationExecutes=false);
            services.AddControllersWithViews().AddFluentValidation();
            services.AddInfrastructure();
            services.AddRazorPages();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                //app.UseExceptionHandler("/Error");
                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
