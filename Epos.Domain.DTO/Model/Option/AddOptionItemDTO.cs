using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddOptionItemDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public virtual String Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public virtual Double Price { get; set; }
        public Double LPrice { get; set; }
        public Double EPrice { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int OptionId { get; set; }
    }
}
