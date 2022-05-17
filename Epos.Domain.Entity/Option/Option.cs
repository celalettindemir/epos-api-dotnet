using Epos.Domain.DTO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Option : BaseEntity
    {
        public virtual ItemType Type { get; set; }
        public virtual String Title { get; set; }
        public virtual ICollection<OptionItem> OptionSelects { get; set; }
        public virtual Boolean DefaultAll { get; set; } = false;
        public virtual Product Product { get; set; }
    }
}
