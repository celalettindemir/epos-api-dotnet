using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// OptionSelect ekler.
        /// </summary>
        /// <param name="model">OptionSelect Ekler</param>
        /// <returns>Eklenen <see cref="OptionItem"/></returns>
        Task<ServiceResponse<OrderDTO>> AddOrder(AddOrderDTO model);
    }
}
