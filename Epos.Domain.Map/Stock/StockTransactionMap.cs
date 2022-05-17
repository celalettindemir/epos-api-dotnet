using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class StockTransactionMap : BaseEntityMap<StockTransaction>
    {
        public StockTransactionMap()
        {
            Table("stock_transactions");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Amount).Column("Amount");
            Map(p => p.Description).Column("Description");

            References(p => p.Stock).Column("StockId").Cascade.All().NotFound.Ignore().Not.LazyLoad();
        }
    }
}
