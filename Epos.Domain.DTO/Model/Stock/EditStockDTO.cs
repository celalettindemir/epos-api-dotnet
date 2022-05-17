using Epos.Domain.DTO.Definitions.Stock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditStockDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public StockType Type { get; set; }
    }
}
