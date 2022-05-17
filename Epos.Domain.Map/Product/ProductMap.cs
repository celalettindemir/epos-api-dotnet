using Epos.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class ProductMap : BaseEntityMap<Product>
    {
        public ProductMap()
        {
            Table("products");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Name).Column("Name");

            References(p => p.Category).Column("CategoryId").Cascade.All().NotFound.Ignore().LazyLoad();

            HasMany(p => p.ProductPortions)
                .Table("product_portions")
                .KeyColumn("ProductId").Cascade.All().LazyLoad();
        }
    }
}
