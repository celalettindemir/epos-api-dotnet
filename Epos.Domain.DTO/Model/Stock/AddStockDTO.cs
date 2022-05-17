using Epos.Domain.DTO.Definitions.Stock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddStockDTO
    {
        public string Name { get; set; }
        public double Amount { get; set; } = 0.0;
        public StockType Type { get; set; }
    }
}
