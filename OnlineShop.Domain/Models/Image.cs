using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models
{
    public class Image
    {
        int Id { get; set; }
        int ProductId { get; set; }
        string Path { get; set; }
    }
}
