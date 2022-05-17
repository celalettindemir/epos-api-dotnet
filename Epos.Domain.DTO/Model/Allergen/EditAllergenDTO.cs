using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditAllergenDTO
    {
        [Required(ErrorMessage = "Alerjen Id zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(500, ErrorMessage = "Alerjen adı 500 karakterden uzun olamaz!")]
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
