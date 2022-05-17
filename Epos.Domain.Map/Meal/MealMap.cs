using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class MealMap : BaseEntityMap<Meal>
    {
        public MealMap()
        {
            Table("meal");

            Map(p => p.Name).Column("Name");
            Map(p => p.ButtonWidth).Column("ButtonWidth");

            //References(p => p.ProductPortions).Column("MealId").Cascade.All().NotFound.Ignore().LazyLoad();

            /*HasMany(p => p.ProductPortions)
                .Table("product_portions")
                .KeyColumn("MealId").Cascade.All().LazyLoad();*/
        }
    }
}
