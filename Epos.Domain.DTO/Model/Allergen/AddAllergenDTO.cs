using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddAllergenDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(500, ErrorMessage = "Alerjen adı 500 karakterden uzun olamaz!")]
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
