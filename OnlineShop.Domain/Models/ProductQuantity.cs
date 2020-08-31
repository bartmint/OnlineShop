namespace OnlineShop.Domain.Models
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int AmmountOfProduct { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
