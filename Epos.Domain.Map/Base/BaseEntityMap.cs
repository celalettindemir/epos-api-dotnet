using Epos.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.CreatedDate).Column("CreatedDate");
            Map(x => x.UpdatedBy).Column("UpdatedBy").Nullable();
            Map(x => x.UpdatedDate).Column("UpdatedDate").Nullable();
        }

    }
}
