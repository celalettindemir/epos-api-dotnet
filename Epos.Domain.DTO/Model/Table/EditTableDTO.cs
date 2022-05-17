using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditTableDTO
    {
        [Required(ErrorMessage = "Masa Id değeri zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Masa adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Masa adı en fazla {1} karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Alan zorunludur.")]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "Masa pozisyonu zorunludur.")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Masa pozisyonu için geçersiz değer.")]
        public int PositionId { get; set; }
    }
}
