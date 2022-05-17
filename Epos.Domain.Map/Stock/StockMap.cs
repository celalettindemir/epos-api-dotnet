using Epos.Domain.DTO.Definitions.Stock;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class StockMap : BaseEntityMap<Stock>
    {
        public StockMap()
        {
            Table("stocks");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Name).Column("Name");
            Map(p => p.Amount).Column("Amount");
            Map(p => p.Type).Column("Type").CustomType<StockType>();

            HasMany(p => p.StockTransactions)
                .Table("stock_transactions")
                .KeyColumn("StockId").Cascade.All().LazyLoad();
        }
    }
}
