using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epos.Domain.DTO.Model;
using Epos.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Epos.Api.Controllers
{
    [Route("Stock")]
    [ApiController]
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("AddStock")]
        [SwaggerOperation(Description = "Stok ekler.")]
        public async Task<IActionResult> AddStock(AddStockDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _stockService.AddStock(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("AddStockTransaction")]
        [SwaggerOperation(Description = "Stok kaydı ekler.")]
        public async Task<IActionResult> AddStockTransaction(AddStockTransactionDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _stockService.AddStockTransaction(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetStock")]
        [SwaggerOperation(Description = "Id'si verilen stoğu getirir.")]
        public async Task<IActionResult> GetStock(int id)
        {
            var response = await _stockService.GetStock(id);
            return Ok(response);
        }

        [HttpGet("GetStocks")]
        [SwaggerOperation(Description = "Tüm stokları getirir.")]
        public async Task<IActionResult> GetStocks()
        {
            var response = await _stockService.GetStocks();
            return Ok(response);
        }

        [HttpGet("GetStockTransactions")]
        [SwaggerOperation(Description = "Tüm stok kayıtlarını getirir.")]
        public async Task<IActionResult> GetStockTransactions()
        {
            var response = await _stockService.GetStockTransactions();
            return Ok(response);
        }

        [HttpGet("GetStockTransactions/{id}")]
        [SwaggerOperation(Description = "Id'si verilen stoğun kayıtlarını getirir.")]
        public async Task<IActionResult> GetStockTransactions(int id)
        {
            var response = await _stockService.GetStockTransactions(id);
            return Ok(response);
        }

        [HttpPut("UpdateStock")]
        [SwaggerOperation(Description = "Gönderilen stoğu günceller.")]
        public async Task<IActionResult> UpdateStock(EditStockDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _stockService.UpdateStock(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteStock/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip stoğu siler.")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var response = await _stockService.DeleteStock(id);
            return Ok(response);
        }
    }
}
