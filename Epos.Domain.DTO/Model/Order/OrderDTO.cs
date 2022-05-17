using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public double TotalPrice { get; set; }
        public int State { get; set; }
        public List<OrderItemDTO> orderItems { get; set; }
    }
}
