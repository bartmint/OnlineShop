using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;

namespace OnlineShop.Infrastructure.DAL
{
    public class ApplicationDb : IdentityDbContext<UserData>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Seed();

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> CartItems { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
