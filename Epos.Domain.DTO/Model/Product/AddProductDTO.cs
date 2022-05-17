using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddProductDTO
    {
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ürün adı 100 karakterden uzun olamaz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        public int CategoryId { get; set; }
    }
}
