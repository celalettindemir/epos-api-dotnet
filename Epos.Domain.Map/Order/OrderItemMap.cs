using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class OrderItemMap : BaseEntityMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("order_items");
            Map(p => p.TotalPrice).Column("TotalPrice");
            Map(p => p.Count).Column("Count");

            References(p => p.Order).Column("OrderId").Cascade.All().NotFound.Ignore().LazyLoad();
            References(p => p.ProductPortion).Column("ProductPortionId").Cascade.All().NotFound.Ignore().LazyLoad();
            HasMany(p => p.OrderOptions)
                .Table("order_items")
                .KeyColumn("OrderId").Cascade.All().LazyLoad();

        }
    }
}
