using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models.Common
{
   public class BaseEntity:AuditableModel
    {
        public int Id { get; set; }
    }
}
