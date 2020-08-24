using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.DAL
{
    public class ApplicationDb:IdentityDbContext<UserData>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
