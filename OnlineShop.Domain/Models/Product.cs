using OnlineShop.Domain.Enums.ProductItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Model { get; set; }
        public string System { get; set; }
        public string CPU { get; set; }
        public string RamMemorry { get; set; }
        public string HardDrive { get; set; }
        public string Weight { get; set; }
        public string GraphicCard { get; set; }
        public Producent ProductionCompany { get; set; }
        public Varranty Warranty { get; set; }
        public MemoryType MemoryType { get; set; }
        public int ProductionYear { get; set; }
        public string ScreenResolution { get; set; }
        public Ammount Ammount { get; set; }
        public List<Image> Paths { get; set; } = new List<Image>();

    }
}
