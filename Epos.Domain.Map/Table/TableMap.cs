using Epos.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class TableMap : BaseEntityMap<Table>
    {
        public TableMap()
        {
            Table("tables");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Name).Column("Name");
            Map(p => p.PositionId).Column("PositionId");
            Map(p => p.OrderId).Column("OrderId");
            Map(p => p.WaiterId).Column("WaiterId");

            References(p => p.Place).Column("PlaceId").Cascade.All().NotFound.Ignore().Not.LazyLoad();
        }
    }
}
