
using System.Collections.Generic;
using System.Text;
using Epos.Domain.Entity;

namespace Epos.Domain.Map
{
    public class OptionMap : BaseEntityMap<Option>
    {
        public OptionMap()
        {
            Table("options");
            Map(p => p.Type).Column("Type");
            Map(p => p.Title).Column("Title");
            Map(p => p.DefaultAll).Column("DefaultAll");
            References(p => p.Product).Column("ProductId").Cascade.All().NotFound.Ignore().LazyLoad();

            HasMany(p => p.OptionSelects)
                .Table("option_items")
                .KeyColumn("OptionId").Cascade.All().LazyLoad();
        }
    }
}
