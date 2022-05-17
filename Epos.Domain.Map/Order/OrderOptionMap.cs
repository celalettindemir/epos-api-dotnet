using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class OrderOptionMap : BaseEntityMap<OrderOption>
    {
        public OrderOptionMap()
        {
            Table("order_options");
            Map(p => p.SelectType).Column("SelectType");

            References(p => p.OptionItem).Column("OptionItemId").Cascade.All().NotFound.Ignore().LazyLoad();
            References(p => p.OrderItem).Column("OrderItemId").Cascade.All().NotFound.Ignore().LazyLoad();

        }
    }
}
