using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Order : BaseEntity
    {
        public virtual int State { get; set; }
        public virtual int Type { get; set; }
        public virtual Double TotalPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
