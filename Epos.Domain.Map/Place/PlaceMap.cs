using Epos.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class PlaceMap : BaseEntityMap<Place>
    {
        public PlaceMap()
        {
            Table("places");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Name).Column("Name");

            HasMany(p => p.Tables)
                .Table("tables")
                .KeyColumn("PlaceId").Cascade.All().Not.LazyLoad();
        }
    }
}
