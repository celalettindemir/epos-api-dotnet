using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Table : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Place Place { get; set; }
        public virtual int PositionId { get; set; }
        public virtual int? WaiterId { get; set; }
        public virtual int? OrderId { get; set; }
    }
}
