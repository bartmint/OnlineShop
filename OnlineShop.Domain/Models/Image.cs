using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
    }
}
