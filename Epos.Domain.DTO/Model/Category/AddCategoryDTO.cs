using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(100, ErrorMessage = "Kategori adı 100 karakterden uzun olamaz!")]
        public string Name { get; set; }
        public double ButtonWidth { get; set; }
    }
}
