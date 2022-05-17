using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IProductPortionService
    {
        /// <summary>
        /// Ürün eklenir
        /// </summary>
        /// <param name="model">Ürün</param>
        /// <returns>Eklenen ürün</returns>
        Task<ServiceResponse<ProductPortionDTO>> AddProductPortion(AddProductPortionDTO model);

        /// <summary>
        /// Ürün eklenir
        /// </summary>
        /// <param name="model">Ürün</param>
        /// <returns>Eklenen ürün</returns>
        Task<ServiceResponse<ProductPortionDTO>> UpdateProductPortion(ProductPortionDTO model);
        
        /// <summary>
        /// Bütün ürünleri döndürür
        /// </summary>
        /// <returns>Ürün listesi</returns>
        Task<ServiceResponse<List<ProductPortion>>> GetProductPortions();
        /// <summary>
        /// Id girilen ürün döndürür
        /// </summary>
        /// <returns>Ürün listesi</returns>
        Task<ServiceResponse<ProductPortion>> GetProductPortion(int Id);

    }
}
