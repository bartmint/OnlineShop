using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.DAL
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder model)
        {
            model.Entity<Product>().HasData(
                new Product
                {
                    Id = 101,
                    ProductionCompany = 0,
                    Model = "Hp",
                    System = "Windows10",
                    CPU = "Ryzen 5-3600",
                    RamMemorry = "8",
                    HardDrive = "2",
                    Weight = "2",
                    GraphicCard = "nvidia 2060",
                    Value = 2500,
                    ProductionYear = 2019,
                    ScreenResolution = "21",
                    Description = "blabla"
                },
                new Product
                {
                    Id = 102,
                    ProductionCompany = 0,
                    Model = "Hp",
                    System = "Windows10",
                    CPU = "Ryzen 5-3600",
                    RamMemorry = "8",
                    HardDrive = "2",
                    Weight = "2",
                    GraphicCard = "nvidia 2060",
                    Value = 2500,
                    ProductionYear = 2019,
                    ScreenResolution = "21",
                    Description = "blabla"
                },
                new Product
                {
                    Id = 103,
                    ProductionCompany = 0,
                    Model = "Hp",
                    System = "Windows10",
                    CPU = "Ryzen 5-3600",
                    RamMemorry = "8",
                    HardDrive = "2",
                    Weight = "2",
                    GraphicCard = "nvidia 2060",
                    Value = 2500,
                    ProductionYear = 2019,
                    ScreenResolution = "21",
                    Description = "blabla"
                });

        }
    }
}
