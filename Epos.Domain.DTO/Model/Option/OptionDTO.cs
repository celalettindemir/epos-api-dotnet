using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public String Title { get; set; }
        public List<OptionItemDTO> OptionItems { get; set; }
        public Boolean DefaultAll { get; set; } = false;
        public int ProductId { get; set; }
    }
}
