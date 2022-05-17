using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IAllergenService
    {
        /// <summary>
        /// Alerjen ekler.
        /// </summary>
        /// <param name="model">Alerjen ekle modeli</param>
        /// <returns>Eklenen <see cref="Allergen"/></returns>
        Task<ServiceResponse<Allergen>> AddAllergen(AddAllergenDTO model);

        /// <summary>
        /// Id'si gönderilen Alerjeni getirir.
        /// </summary>
        /// <param name="id">Alerjen Id</param>
        /// <returns><see cref="Allergen"/></returns>
        Task<ServiceResponse<Allergen>> GetAllergen(int id);

        /// <summary>
        /// Bütün Alerjenleri getirir.
        /// </summary>
        /// <returns><see cref="IList{Allergen}"/></returns>
        Task<ServiceResponse<IList<Allergen>>> GetAllergens();

        /// <summary>
        /// Alerjeni verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Alerjen güncelle model</param>
        /// <returns><see cref="Allergen"/> Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdateAllergen(EditAllergenDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan Alerjeni siler.
        /// </summary>
        /// <param name="id">Alerjen Id'si</param>
        /// <returns><see cref="Allergen"/> Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteAllergen(int id);
    }
}
