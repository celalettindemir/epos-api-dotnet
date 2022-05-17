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
    [Route("Allergen")]
    [ApiController]
    public class AllergenController : BaseController
    {
        private readonly IAllergenService _allergenService;

        public AllergenController(IAllergenService allergenService)
        {
            _allergenService = allergenService;
        }

        [HttpPost("AddAllergen")]
        [SwaggerOperation(Description = "Alerjen ekler.")]
        public async Task<IActionResult> AddAllergen(AddAllergenDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _allergenService.AddAllergen(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAllergen")]
        [SwaggerOperation(Description = "Id'si verilen alerjeni getirir.")]
        public async Task<IActionResult> GetAllergen(int id)
        {
            var response = await _allergenService.GetAllergen(id);
            return Ok(response);
        }

        [HttpGet("GetAllergens")]
        [SwaggerOperation(Description = "Tüm alerjenleri getirir.")]
        public async Task<IActionResult> GetAllergens()
        {
            var response = await _allergenService.GetAllergens();
            return Ok(response);
        }

        [HttpPut("UpdateAllergen")]
        [SwaggerOperation(Description = "Gönderilen alerjeni günceller.")]
        public async Task<IActionResult> UpdateAllergen(EditAllergenDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _allergenService.UpdateAllergen(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteAllergen/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip alerjeni siler.")]
        public async Task<IActionResult> DeleteAllergen(int id)
        {
            var response = await _allergenService.DeleteAllergen(id);
            return Ok(response);
        }
    }
}
