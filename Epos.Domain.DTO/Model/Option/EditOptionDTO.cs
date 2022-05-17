using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditOptionDTO
    {
        [Required(ErrorMessage = "Option Id değeri zorunludur.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public ItemType Type { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public String Title { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public Boolean DefaultAll { get; set; } = false;
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int ProductId { get; set; }
    }
}
