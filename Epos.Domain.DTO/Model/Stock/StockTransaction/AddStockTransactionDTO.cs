using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class AddStockTransactionDTO
    {
        [Required(ErrorMessage = "Stok id zorunludur.")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur.")]
        [Range(0.001, Double.PositiveInfinity, ErrorMessage = "Miktar, sıfıra eşit ya da sıfırdan küçük olamaz.")]
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
