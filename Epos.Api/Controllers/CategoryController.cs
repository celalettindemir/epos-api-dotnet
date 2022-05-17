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
    [Route("Category")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("AddCategory")]
        [SwaggerOperation(Description = "Kategori ekler.")]
        public async Task<IActionResult> AddCategory(AddCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.AddCategory(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetCategory")]
        [SwaggerOperation(Description = "Id'si verilen kategoriyi getirir.")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _categoryService.GetCategory(id);
            return Ok(response);
        }

        [HttpGet("GetCategories")]
        [SwaggerOperation(Description = "Tüm kategorileri getirir.")]
        public async Task<IActionResult> GetAllergens()
        {
            var response = await _categoryService.GetCategories();
            return Ok(response);
        }

        [HttpPut("UpdateCategory")]
        [SwaggerOperation(Description = "Gönderilen kategoriyi günceller.")]
        public async Task<IActionResult> UpdateCategory(EditCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.UpdateCategory(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteCategory/{id}")]
        [SwaggerOperation(Description = "Gönderilen Id'ye sahip kategoriyi siler.")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return Ok(response);
        }
    }
}
