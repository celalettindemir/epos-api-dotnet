using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddProductPortionDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product zorunludur.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Meal zorunludur.")]
        public int MealId { get; set; }

        [MaxLength(100, ErrorMessage = "Ürün başlığı 100 karakterden uzun olamaz!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.0, Double.PositiveInfinity, ErrorMessage = "Ürün fiyatı negatif bir değer olamaz!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Ürün pozisyonu zorunludur.")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Masa pozisyonu için geçersiz değer.")]
        public int PositionId { get; set; }
        public string Color { get; set; }
    }
}
