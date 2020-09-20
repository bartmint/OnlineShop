using AutoMapper;
using OnlineShop.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.Product
{
    public class ProductForListVM : IMapFrom<OnlineShop.Domain.Models.Product>
    {
        public int ProductId { get; set; }
        public string Producent { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public string PathToImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OnlineShop.Domain.Models.Product, ProductForListVM>()
              .ForMember(p => p.ProductId, opt => opt.MapFrom(g => g.Id))
              .ForMember(p => p.Producent, opt => opt.MapFrom(g => g.ProductionCompany))
              .ForMember(p => p.Model, opt => opt.MapFrom(g => g.Model))
              .ForMember(p => p.Value, opt => opt.MapFrom(g => g.Value))
              .ForMember(p => p.PathToImage, opt => opt.MapFrom(g => "~/Images/" + g.Paths[0].Path));
        }

    }
}
