using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class EditCategoryDTO
    {
        [Required(ErrorMessage = "Kategori Id değeri zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(100, ErrorMessage = "Kategori adı 100 karakterden uzun olamaz!")]
        public string Name { get; set; }

        public double ButtonWidth { get; set; }
    }
}
