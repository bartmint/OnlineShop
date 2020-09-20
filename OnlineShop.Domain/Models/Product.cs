using OnlineShop.Domain.Enums.ProductItems;
using OnlineShop.Domain.Models.Common;
using System.Collections.Generic;

namespace OnlineShop.Domain.Models
{
    public class Product: BaseEntity
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Model { get; set; }
        public string System { get; set; }
        public string CPU { get; set; }
        public string HardDrive { get; set; }
        public string Weight { get; set; }
        public string GraphicCard { get; set; }
        public Producent ProductionCompany { get; set; }
        public Varranty Warranty { get; set; }
        public MemoryType MemoryType { get; set; }
        public int ProductionYear { get; set; }
        public int ScreenResolution { get; set; }
        public  Ammount Ammount { get; set; }
        public virtual List<Image> Paths { get; set; }
        public Product()
        {
            Paths = new List<Image>();
        }
    }
}
