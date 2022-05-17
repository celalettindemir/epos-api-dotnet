using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class OptionItemDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public Double LPrice { get; set; }
        public Double EPrice { get; set; }
    }
}
