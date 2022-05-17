using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public enum ItemType
    {
        Any=1,
        Portion=2,
        One=3
    }
    public class AddOptionDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public ItemType Type { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public String Title { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public Boolean DefaultAll { get; set; } = false;
        public int ProductId { get; set; }
    }
}
