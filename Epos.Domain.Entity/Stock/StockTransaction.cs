using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class StockTransaction : BaseEntity
    {
        public virtual Stock Stock { get; set; }
        public virtual double Amount { get; set; }
        public virtual string Description { get; set; }
    }
}
