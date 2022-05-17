using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class OrderMap : BaseEntityMap<Order>
    {
        public OrderMap()
        {
            Table("orders");
            Map(p => p.TotalPrice).Column("TotalPrice");
            Map(p => p.State).Column("State");
            Map(p => p.Type).Column("Type");

            HasMany(p => p.OrderItems)
                .Table("order_items")
                .KeyColumn("OrderId").Cascade.All().LazyLoad();
        }
    }
}
