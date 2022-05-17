using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class OrderOptionItemDTO
    {
        public int Id { get; set; }
        public OptionItemDTO OptionItem { get; set; }
        public int SelectType { get; set; }
    }
}
