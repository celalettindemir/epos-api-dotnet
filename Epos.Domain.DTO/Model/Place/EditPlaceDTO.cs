using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditPlaceDTO
    {
        [Required(ErrorMessage = "Alan Id değeri zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Alan adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Alan adı 100 karakterden uzun olamaz.")]
        public string Name { get; set; }
    }
}
