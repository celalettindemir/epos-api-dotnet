using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddOrderOptionItem
    {
        public OptionItemDTO OptionItemDTO { get; set; }
        public int SelectType { get; set; }
    }
}
