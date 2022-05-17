using Epos.Domain.DTO.Definitions.Stock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Stock : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual double Amount { get; set; }
        public virtual StockType Type { get; set; }

        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
    }
}
