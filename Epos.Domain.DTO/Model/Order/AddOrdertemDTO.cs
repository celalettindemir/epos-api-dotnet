using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddOrdertemDTO
    {
        public int Count { get; set; }
        public Double TotalPrice { get; set; }
        public int ProductPortionId { get; set; }
        public List<AddOrderOptionItem> OrderOptionItems { get; set; }
    }
}
