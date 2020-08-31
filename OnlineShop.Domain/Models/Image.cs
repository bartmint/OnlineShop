namespace OnlineShop.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
    }
}
