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
    [Route("Place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost("AddPlace")]
        [SwaggerOperation(Description = "Alan ekler.")]
        public async Task<IActionResult> AddPlace(AddPlaceDTO model)
        {
            var response = await _placeService.AddPlace(model);
            return Ok(response);
        }

        [HttpGet("GetPlaces")]
        [SwaggerOperation(Description = "Tüm alanları ekler.")]
        public async Task<IActionResult> GetPlaces()
        {
            return Ok(await _placeService.GetPlaces());
        }

        [HttpGet("GetPlace/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip alanı getirir.")]
        public async Task<IActionResult> GetPlace(int id)
        {
            return Ok(await _placeService.GetPlace(id));
        }

        [HttpPut("UpdatePlace")]
        [SwaggerOperation(Description = "Gönderilen alanı günceller.")]
        public async Task<IActionResult> UpdatePlace(EditPlaceDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _placeService.UpdatePlace(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeletePlace/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip alanı siler.")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var response = await _placeService.DeletePlace(id);
            return Ok(response);
        }
    }
}
