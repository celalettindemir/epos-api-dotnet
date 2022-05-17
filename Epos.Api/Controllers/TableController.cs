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
    [Route("Table")]
    [ApiController]
    public class TableController : BaseController
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost("AddTable")]
        [SwaggerOperation(Description = "Masa ekler.")]
        public async Task<IActionResult> AddTable(AddTableDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _tableService.AddTable(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetTable/{id}")]
        [SwaggerOperation(Description = "Id'si verilen masayı getirir.")]
        public async Task<IActionResult> GetTable(int id)
        {
            return Ok(await _tableService.GetTable(id));
        }

        [HttpGet("GetTables")]
        [SwaggerOperation(Description = "Tüm masaları getirir.")]
        public async Task<IActionResult> GetTables()
        {
            return Ok(await _tableService.GetTables());
        }

        [HttpPut("UpdateTable")]
        [SwaggerOperation(Description = "Gönderilen masayı günceller.")]
        public async Task<IActionResult> UpdateTable(EditTableDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _tableService.UpdateTable(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteTable/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip masayı siler.")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var response = await _tableService.DeleteTable(id);
            return Ok(response);
        }
    }
}
