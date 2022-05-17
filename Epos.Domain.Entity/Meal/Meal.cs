using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Meal:BaseEntity
    {
        public virtual String Name { get; set; }
        public virtual double ButtonWidth { get; set; }
        public virtual ICollection<ProductPortion> ProductPortions { get; set; }

    }
}
