using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditOptionItemDTO
    {
        [Required(ErrorMessage = "Option Id değeri zorunludur.")]
        public int Id { get; set; }
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
