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
    [Route("Meal")]
    [ApiController]
    public class MealController : BaseController
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpPost("AddMeal")]
        [SwaggerOperation(Description = "Alerjen ekler.")]
        public async Task<IActionResult> AddMeal(AddMealDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _mealService.AddMeal(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetMeal")]
        [SwaggerOperation(Description = "Id'si verilen alerjeni getirir.")]
        public async Task<IActionResult> GetMeal(int id)
        {
            var response = await _mealService.GetMeal(id);
            return Ok(response);
        }

        [HttpGet("GetMeals")]
        [SwaggerOperation(Description = "Tüm alerjenleri getirir.")]
        public async Task<IActionResult> GetMeals()
        {
            var response = await _mealService.GetMeals();
            return Ok(response);
        }

        [HttpDelete("DeleteMeal/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip alerjeni siler.")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var response = await _mealService.DeleteMeal(id);
            return Ok(response);
        }
    }
}
