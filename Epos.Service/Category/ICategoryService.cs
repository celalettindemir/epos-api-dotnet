using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface ICategoryService
    {
        /// <summary>
        /// Kategori ekler.
        /// </summary>
        /// <param name="model">Kategori ekle modeli</param>
        /// <returns>Kategori</returns>
        Task<ServiceResponse<CategoryDTO>> AddCategory(AddCategoryDTO model);

        /// <summary>
        /// Id'si gönderilen kategoriyi getirir.
        /// </summary>
        /// <param name="id">Kategori Id</param>
        /// <returns>Kategori</returns>
        Task<ServiceResponse<Category>> GetCategory(int id);

        /// <summary>
        /// Bütün kategorileri getirir.
        /// </summary>
        /// <returns>Kategori listesi</returns>
        Task<ServiceResponse<IList<CategoryDTO>>> GetCategories();

        /// <summary>
        /// Kategoriyi verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Kategori güncelle model</param>
        /// <returns>Kategori Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdateCategory(EditCategoryDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan kategoriyi siler.
        /// </summary>
        /// <param name="id">Kategori Id'si</param>
        /// <returns>Kategori Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteCategory(int id);

    }
}
