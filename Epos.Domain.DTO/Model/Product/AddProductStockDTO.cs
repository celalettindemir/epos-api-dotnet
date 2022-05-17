using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddProductStockDTO
    {
        [MaxLength(100, ErrorMessage = "Product zorunludur.")]
        public string ProductPortionId { get; set; }

        [MaxLength(100, ErrorMessage = "Stock zorunludur.")]
        public int StockId { get; set; }

        [MaxLength(100, ErrorMessage = "Miktar zorunludur.")]
        public double Amount { get; set; }
    }
}
