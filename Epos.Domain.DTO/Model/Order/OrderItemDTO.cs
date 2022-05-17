using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public Double TotalPrice { get; set; }
        public ProductPortionDTO ProductPortion { get; set; }
        public List<OrderOptionItemDTO> OrderOptionItems { get; set; }
    }
}
