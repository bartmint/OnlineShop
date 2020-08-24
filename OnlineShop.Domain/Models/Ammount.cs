using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models
{
   public class Ammount
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }//dodac produktID jesli nie zadziala, ale powinno

    }
}
