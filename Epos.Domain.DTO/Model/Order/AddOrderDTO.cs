using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddOrderDTO
    {
        public int Type { get; set; }
        public int State { get; set; }
        public List<AddOrdertemDTO> OrderItems { get; set; }
    }
}
