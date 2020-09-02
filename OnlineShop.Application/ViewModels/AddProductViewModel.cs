using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Enums.ProductItems;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Producent field is required")]
        public Producent ProductionCompany { get; set; }
        [Required(ErrorMessage = "Model field is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "System field is required")]
        public string System { get; set; }
        [Required(ErrorMessage = "CPU field is required")]
        public string CPU { get; set; }
        [Required(ErrorMessage = "RamMemorry field is required")]
        public MemoryType MemoryType { get; set; }
        [Required(ErrorMessage = "HardDrive field is required")]
        public string HardDrive { get; set; }
        [Required(ErrorMessage = "weight field is required")]
        public string Weight { get; set; }
        [Required(ErrorMessage = "GraphicCard field is required")]
        public string GraphicCard { get; set; }
        [Required(ErrorMessage = "Price field is required")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "ProductionYear field is required")]
        public int ProductionYear { get; set; }
        [Required(ErrorMessage = "ScreenResolution field is required")]
        public string ScreenResolution { get; set; }
        [Required(ErrorMessage = "Description field is required")]
        public string Description { get; set; }
        public Varranty Warranty { get; set; }
        [MaxLength(3, ErrorMessage ="You cant add more than 3 images")]
        [MinLength(1, ErrorMessage ="You have to add at least 1 image")]
        public List<IFormFile> Images { get; set; }

        [Required(ErrorMessage = "Ammount field is required")]
        public int Ammount { get; set; }
        public AddProductViewModel()
        {
            Images = new List<IFormFile>();
        }

    }
}
