using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class OrderOption : BaseEntity
    {
        public virtual OptionItem OptionItem { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public virtual int SelectType { get; set; }
    }
}
