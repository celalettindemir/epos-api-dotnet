using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class ProductStockMap : BaseEntityMap<ProductStock>
    {
        public ProductStockMap()
        {
            Table("product_stocks");

            Map(p => p.Amount).Column("Amount");

            References(p => p.Stock).Column("StockId").Cascade.All().NotFound.Ignore().LazyLoad();
            References(p => p.ProductPortion).Column("ProductPortionId").Cascade.All().NotFound.Ignore().LazyLoad();
        }
    }
}
