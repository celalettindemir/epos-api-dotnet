using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class CategoryMealMap : BaseEntityMap<CategoryMeal>
    {
        public CategoryMealMap()
        {
            Table("category_meals");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            References(p => p.Category).Column("CategoryId").Cascade.All().NotFound.Ignore().LazyLoad();

            References(p => p.Meal).Column("MealId").Cascade.All().LazyLoad();
        }
    }
}
