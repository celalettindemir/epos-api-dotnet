using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IProductService
    {
        /// <summary>
        /// Ürün eklenir
        /// </summary>
        /// <param name="model">Ürün</param>
        /// <returns>Eklenen ürün</returns>
        Task<ServiceResponse<ProductDTO>> AddProduct(AddProductDTO model);

        /// <summary>
        /// Product ID'ye gore dondurur.
        /// </summary>
        /// <param name="model">Ürün</param>
        /// <returns>Eklenen ürün</returns>

        Task<ServiceResponse<Product>> GetProduct(int productId);
        /// <summary>
        /// Bütün ürünleri döndürür
        /// </summary>
        /// <returns>Ürün listesi</returns>
        Task<ServiceResponse<IList<Product>>> GetProducts();

        /// <summary>
        /// Kategori Id'ye göre ürün döndürür
        /// </summary>
        /// <param name="categoryId">Kategori Id</param>
        /// <returns>Ürün listesi</returns>
        Task<ServiceResponse<IList<Product>>> GetProducts(int categoryId);

        /// <summary>
        /// Kategori Id'ye göre ürün döndürür
        /// </summary>
        /// <param name="categoryId">Kategori Id</param>
        /// <returns>Ürün listesi</returns>
        Task<ServiceResponse<IList<ProductPortion>>> GetPageProductPortions(SelectPageProductDTO model);

        /// <summary>
        /// Kategori Id'ye göre ürün döndürür
        /// </summary>
        /// <returns>Kategory Product listesi</returns>
        Task<ServiceResponse<IList<CategoryProductsViewDTO>>> GetCategoryProducts();


    }
}
