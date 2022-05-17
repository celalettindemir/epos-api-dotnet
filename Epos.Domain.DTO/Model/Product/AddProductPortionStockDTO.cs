using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddProductPortionStockDTO
    {
        [Required(ErrorMessage = "Product zorunludur.")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Meal zorunludur.")]
        public Double Amount { get; set; }
    }
}
