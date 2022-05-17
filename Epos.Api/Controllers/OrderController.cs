using Epos.Domain.DTO.Model;
using Epos.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epos.Api.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrderController : BaseController
    {

        private readonly IOrderService _orderService;
        //private readonly IOptionItemService _optionSelectService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            //_optionSelectService = optionSelectService;
        }
        [HttpPost("AddOrder")]
        [SwaggerOperation(Description = "Order ekler.")]
        public async Task<IActionResult> AddOrder(AddOrderDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderService.AddOrder(model);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}
