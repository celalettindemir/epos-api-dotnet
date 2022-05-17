using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Product : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPortion> ProductPortions { get; set; }
    }
}
