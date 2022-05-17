
using Epos.Domain.Entity;

namespace Epos.Domain.Map
{
    public class OptionSelectMap : BaseEntityMap<OptionItem>
    {
        public OptionSelectMap()
        {
            Table("option_items");
            Map(p => p.Name).Column("Name");
            Map(p => p.Price).Column("Price");
            Map(p => p.LPrice).Column("LPrice");
            Map(p => p.EPrice).Column("EPrice");
            References(p => p.Option).Column("OptionId").Cascade.All().NotFound.Ignore().LazyLoad();

 
        }
    }
}
