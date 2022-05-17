using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class ProductPortion:BaseEntity
    {
        public virtual string Title { get; set; }
        public virtual double Price { get; set; }
        public virtual int PositionId { get; set; }
        public virtual string Color { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
