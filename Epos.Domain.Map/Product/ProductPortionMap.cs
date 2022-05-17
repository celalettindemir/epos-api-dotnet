using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class ProductPortionMap : BaseEntityMap<ProductPortion>
    {
        public ProductPortionMap()
        {
            Table("product_portions");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Color).Column("Color");
            Map(p => p.PositionId).Column("PositionId");
            Map(p => p.Price).Column("Price");
            Map(p => p.Title).Column("Title");


            References(p => p.Meal).Column("MealId").Cascade.All().LazyLoad();

            References(p => p.Product).Column("ProductId").Cascade.All().NotFound.Ignore().LazyLoad();

            HasMany(p => p.ProductStocks)
                .Table("product_stock")
                .KeyColumn("ProductPortionId").Cascade.All().LazyLoad();
        }
        
    }
}

/*
 * 
 * Name Varchar
 * CategoryId int
*/
