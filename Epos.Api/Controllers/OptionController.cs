using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epos.Domain.DTO.Model;
using Epos.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Epos.Api.Controllers
{
    [Route("Option")]
    [ApiController]
    public class OptionController:BaseController
    {
        private readonly IOptionService _optionService;
        private readonly IOptionItemService _optionSelectService;
        public OptionController(IOptionService optionService, IOptionItemService optionSelectService)
        {
            _optionService = optionService;
            _optionSelectService = optionSelectService;
        }

        [HttpPost("AddOption")]
        [SwaggerOperation(Description = "Option ekler.")]
        public async Task<IActionResult> AddOption(AddOptionDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _optionService.AddOption(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetOption")]
        [SwaggerOperation(Description = "Id'si verilen option getirir.")]
        public async Task<IActionResult> GetOption(int id)
        {
            var response = await _optionService.GetOption(id);
            return Ok(response);
        }

        [HttpGet("GetOptions")]
        [SwaggerOperation(Description = "Tüm optionları getirir.")]
        public async Task<IActionResult> GetOptions()
        {
            var response = await _optionService.GetOptions();
            return Ok(response);
        }

        [HttpPut("UpdateOption")]
        [SwaggerOperation(Description = "Gönderilen option günceller.")]
        public async Task<IActionResult> UpdateOption(EditOptionDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _optionService.UpdateOption(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteOption/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip option siler.")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var response = await _optionService.DeleteOption(id);
            return Ok(response);
        }

        [HttpPost("AddOptionSelect")]
        [SwaggerOperation(Description = "Option ekler.")]
        public async Task<IActionResult> AddOptionSelect(AddOptionItemDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _optionSelectService.AddOptionSelect(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetOptionSelect")]
        [SwaggerOperation(Description = "Id'si verilen option getirir.")]
        public async Task<IActionResult> GetOptionSelect(int id)
        {
            var response = await _optionSelectService.GetOptionSelect(id);
            return Ok(response);
        }

        [HttpGet("GetOptionSelects")]
        [SwaggerOperation(Description = "Tüm optionları getirir.")]
        public async Task<IActionResult> GetOptionSelects()
        {
            var response = await _optionSelectService.GetOptionSelects();
            return Ok(response);
        }

        [HttpPut("UpdateOptionSelect")]
        [SwaggerOperation(Description = "Gönderilen option günceller.")]
        public async Task<IActionResult> UpdateOptionSelect(EditOptionItemDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _optionSelectService.UpdateOptionSelect(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteOptionSelect/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip option siler.")]
        public async Task<IActionResult> DeleteOptionSelect(int id)
        {
            var response = await _optionSelectService.DeleteOptionSelect(id);
            return Ok(response);
        }
    }
}
