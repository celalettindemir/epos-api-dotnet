using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using Epos.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Epos.Api.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductPortionService _productPortionService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService, IProductPortionService productPortionService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productPortionService =productPortionService;
        }

        [HttpPost("AddProduct")]
        [SwaggerOperation(Description = "Ürün ekler.")]
        public async Task<IActionResult> AddProduct(AddProductDTO model)
        {
            if  (ModelState.IsValid)
            {
                var response = await _productService.AddProduct(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
        [HttpPost("AddProductPortion")]
        [SwaggerOperation(Description = "Product Portion Add")]
        public async Task<IActionResult> AddProductPortion(AddProductPortionDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productPortionService.AddProductPortion(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
        [HttpPost("UpdateProductPortion")]
        [SwaggerOperation(Description = "Product Portion Add")]
        public async Task<IActionResult> UpdateProductPortion(ProductPortionDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productPortionService.UpdateProductPortion(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
        [HttpGet("GetCategoryProducts")]
        [SwaggerOperation(Description = "Kategoriler ve urunleri listelenir.")]
        public async Task<IActionResult> GetCategoryProducts()
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.GetCategoryProducts();
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}
