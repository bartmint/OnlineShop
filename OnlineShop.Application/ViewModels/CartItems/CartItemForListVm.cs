using AutoMapper;
using OnlineShop.Application.Mapping;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.ViewModels.CartItems
{
    public class CartItemForListVm : IMapFrom<ShoppingCartItem>
    {
        public int ProductId { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public int TotalProductQuantity { get; set; }
        public int QuantityInCart { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingCartItem, CartItemForListVm>()
                .ForMember(s => s.ProductId, opt => opt.MapFrom(a => a.ProductId))
                .ForMember(s => s.QuantityInCart, opt => opt.MapFrom(a => a.Quantity))
                .ForMember(s => s.TotalProductQuantity, opt => opt.MapFrom(a => a.Product.Ammount.Quantity))
                .ForMember(s => s.Value, opt => opt.MapFrom(a => a.Product.Value))
                .ForMember(s => s.Model, opt => opt.MapFrom(a => a.Product.Model));
        }
    }
}
