using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IOptionItemService
    {
        /// <summary>
        /// OptionSelect ekler.
        /// </summary>
        /// <param name="model">OptionSelect Ekler</param>
        /// <returns>Eklenen <see cref="OptionItem"/></returns>
        Task<ServiceResponse<OptionItem>> AddOptionSelect(AddOptionItemDTO model);

        /// <summary>
        /// Id'si gönderilen Optionu getirir.
        /// </summary>
        /// <param name="id">OptionSelect Id</param>
        /// <returns><see cref="OptionItem"/></returns>
        Task<ServiceResponse<OptionItem>> GetOptionSelect(int id);

        /// <summary>
        /// Bütün Alerjenleri getirir.
        /// </summary>
        /// <returns><see cref="IList{OptionSelect}"/></returns>
        Task<ServiceResponse<IList<OptionItem>>> GetOptionSelects();

        /// <summary>
        /// OptionSelect verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">OptionSelect güncelle model</param>
        /// <returns><see cref="Allergen"/> Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdateOptionSelect(EditOptionItemDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan OptionSelect siler.
        /// </summary>
        /// <param name="id">OptionSelect Id'si</param>
        /// <returns><see cref="Allergen"/> Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteOptionSelect(int id);
    }
}
