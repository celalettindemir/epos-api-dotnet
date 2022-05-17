using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual int CreatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual int? UpdatedBy { get; set; }
    }
}
