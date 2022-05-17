using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddPlaceDTO
    {
        [Required(ErrorMessage = "Alan adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Alan adı 100 karakterden uzun olamaz.")]
        public string name { get; set; }
    }
}
