using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Allergen : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Icon { get; set; }
    }
}
