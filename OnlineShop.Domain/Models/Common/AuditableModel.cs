using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models.Common
{
    public class AuditableModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

    }
}
