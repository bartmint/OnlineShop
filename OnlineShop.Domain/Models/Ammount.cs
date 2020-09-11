using OnlineShop.Domain.Models.Common;

namespace OnlineShop.Domain.Models
{
    public class Ammount:BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }

    }
}
