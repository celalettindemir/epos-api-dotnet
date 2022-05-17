using Epos.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class CategoryMap : BaseEntityMap<Category>
    {
        public CategoryMap()
        {
            Table("categories");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.ButtonWidth).Column("ButtonWidth");
            Map(p => p.Name).Column("Name");

            HasMany(p => p.CategoryMeals)
                .Table("category_meals")
                .KeyColumn("CategoryId").Cascade.All().LazyLoad();

            HasMany(p => p.Products)
                .Table("products")
                .KeyColumn("CategoryId").Cascade.All().LazyLoad();
        }
    }
}
