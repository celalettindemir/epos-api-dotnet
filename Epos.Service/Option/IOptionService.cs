using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IOptionService
    {
        /// <summary>
        /// Option ekler.
        /// </summary>
        /// <param name="model">Option Ekler</param>
        /// <returns>Eklenen <see cref="Option"/></returns>
        Task<ServiceResponse<Option>> AddOption(AddOptionDTO model);

        /// <summary>
        /// Id'si gönderilen Optionu getirir.
        /// </summary>
        /// <param name="id">Option Id</param>
        /// <returns><see cref="Option"/></returns>
        Task<ServiceResponse<Option>> GetOption(int id);

        /// <summary>
        /// Bütün Alerjenleri getirir.
        /// </summary>
        /// <returns><see cref="IList{Option}"/></returns>
        Task<ServiceResponse<IList<OptionDTO>>> GetOptions();

        /// <summary>
        /// Option verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Option güncelle model</param>
        /// <returns><see cref="Allergen"/> Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdateOption(EditOptionDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan Option siler.
        /// </summary>
        /// <param name="id">Option Id'si</param>
        /// <returns><see cref="Allergen"/> Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteOption(int id);
    }
}
