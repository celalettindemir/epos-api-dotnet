using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Map
{
    public class AllergenMap : BaseEntityMap<Allergen>
    {
        public AllergenMap()
        {
            Table("allergens");

            Id(p => p.Id).GeneratedBy.Assigned().GeneratedBy.Identity();

            Map(p => p.Name).Column("Name");
            Map(p => p.Icon).Column("Icon");
        }
    }
}
