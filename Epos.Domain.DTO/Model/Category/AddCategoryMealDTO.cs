using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddCategoryMealDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int MealId { get; set; }
    }
}
