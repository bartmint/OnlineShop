using AutoMapper;
using OnlineShop.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class CartItemForVm:IMapFrom<OnlineShop.Domain.Models.Product>
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int TotalProductQuantity { get; set; }
        public int QuantityInCart { get; set; }
        public decimal Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OnlineShop.Domain.Models.Product, CartItemForVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Value));
        }

    }
}
