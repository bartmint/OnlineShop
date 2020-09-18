using AutoMapper;
using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Mapping;
using OnlineShop.Domain.Enums.ProductItems;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Application.ViewModels.Product
{
    public class NewProductVM:IMapFrom<OnlineShop.Domain.Models.Product>
    {
        public int Id { get; set; }
        public int Ammount { get; set; }
        public Producent ProductionCompany { get; set; }
        public string Model { get; set; }
        public string System { get; set; }
        public string CPU { get; set; }
        public MemoryType MemoryType { get; set; }
        public string HardDrive { get; set; }
        public string Weight { get; set; }
        public string GraphicCard { get; set; }
        public decimal Value { get; set; }
        public int ProductionYear { get; set; }
        public string ScreenResolution { get; set; }
        public string Description { get; set; }
        public Varranty Warranty { get; set; }
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewProductVM, OnlineShop.Domain.Models.Product>()
              .ForMember(s => s.Paths, opt => opt.Ignore())
              .ForMember(s => s.Ammount, opt => opt.Ignore());


            profile.CreateMap<OnlineShop.Domain.Models.Product, NewProductVM>()
              .ForMember(s => s.Ammount, opt => opt.MapFrom(a => a.Ammount.Quantity))
              .ForMember(s => s.Images, opt => opt.Ignore());
        }
    }
}
