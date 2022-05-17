using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Place : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
