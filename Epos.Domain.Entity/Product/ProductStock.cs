using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class ProductStock:BaseEntity
    {
        public virtual ProductPortion ProductPortion { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual double Amount { get; set; }
    }
}
