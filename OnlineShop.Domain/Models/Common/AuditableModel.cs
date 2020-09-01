using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        public DateTime CraetedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModeifiedDateTime { get; set; }

    }
}
