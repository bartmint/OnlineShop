using AutoMapper;
using FluentValidation;
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
    public class NewProductVM : IMapFrom<OnlineShop.Domain.Models.Product>
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
        public int ScreenResolution { get; set; }
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
    public class NewProductValidation : AbstractValidator<NewProductVM>
    {
        public NewProductValidation()
        {
            RuleFor(x => x.Ammount).NotEmpty();
            RuleFor(x => x.CPU).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.System).NotEmpty();
            RuleFor(x => x.ProductionCompany).NotNull().WithMessage("Podaj producenta");
            RuleFor(x => x.MemoryType).NotNull();
            RuleFor(x => x.HardDrive).NotEmpty();
            RuleFor(x => x.Weight).NotEmpty();
            RuleFor(x => x.GraphicCard).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.ProductionYear).NotEmpty();
            RuleFor(x => x.ProductionYear).GreaterThan(2000);
            RuleFor(x => x.ProductionYear).LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Rok produkcji nie moze byc wiekszy niz aktualny");
            RuleFor(x => x.ScreenResolution).NotEmpty();
            RuleFor(x => x.ScreenResolution).GreaterThanOrEqualTo(13).WithMessage("Minimalny rozmiar ekranu to 13pixeli");
            RuleFor(x => x.ScreenResolution).LessThanOrEqualTo(30).WithMessage("Maksymalny rozmiar ekranu to 40pixeli");
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).Length(30, 200);
            RuleFor(x => x.Warranty).NotEmpty();
            RuleFor(x => x.Images).NotEmpty();
            RuleFor(x => x.Images).Must(x => x.Count>=1).WithMessage("Dodaj przynajmniej 1 obraz");
            RuleFor(x => x.Images).Must(x => x.Count<=3).WithMessage("Nie mozna dodac wiecej niz 3 obrazy");

            //czemu nie dziala?
            //RuleForEach(x => x.Images).ChildRules(x =>
            //{
            //    x.RuleFor(y => y.FileName.EndsWith("png") || y.FileName.EndsWith("jpeg") || y.FileName.EndsWith("jpg"));
            //    x.RuleFor(y => y.Length).GreaterThanOrEqualTo(100).WithMessage("Twoj obraz jest zbyt maly");
            //    x.RuleFor(y => y.Length).LessThanOrEqualTo(300).WithMessage("Twoj obraz jest zbyt duzy");
            //}).WithMessage("Podaj odpowiedni typ");

        }

    }


} 

   
