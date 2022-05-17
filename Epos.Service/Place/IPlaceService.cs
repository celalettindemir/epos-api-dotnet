using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IPlaceService
    {
        /// <summary>
        /// Alan ekler
        /// </summary>
        /// <param name="model">Alan ekle model</param>
        /// <returns>Eklenen Alan</returns>
        Task<ServiceResponse<Place>> AddPlace(AddPlaceDTO model);

        /// <summary>
        /// Id'si verilen alanı getirir.
        /// </summary>
        /// <param name="Id">Alan Id'si</param>
        /// <returns>Alan</returns>
        Task<ServiceResponse<Place>> GetPlace(int Id);

        /// <summary>
        /// Bütün alanları getirir.
        /// </summary>
        /// <returns>Alan Listesi</returns>
        Task<ServiceResponse<IList<Place>>> GetPlaces();

        /// <summary>
        /// Alanı verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Alan güncelle model</param>
        /// <returns>Alan Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdatePlace(EditPlaceDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan alanı siler.
        /// </summary>
        /// <param name="id">Alan Id'si</param>
        /// <returns>Alan Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeletePlace(int id);
    }
}
