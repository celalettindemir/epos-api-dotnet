using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class OrderItem : BaseEntity
    {
        public virtual Double TotalPrice { get; set; }
        public virtual int Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductPortion ProductPortion { get; set; }
        public virtual ICollection<OrderOption> OrderOptions { get; set; }
    }
}
