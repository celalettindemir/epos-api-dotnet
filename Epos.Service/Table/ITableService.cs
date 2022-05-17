using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface ITableService
    {
        /// <summary>
        /// Masa ekler.
        /// </summary>
        /// <param name="model">Masa ekle modeli</param>
        /// <returns>Eklenen Masa</returns>
        Task<ServiceResponse<Table>> AddTable(AddTableDTO model);

        /// <summary>
        /// Id'si verilen masayı getirir.
        /// </summary>
        /// <param name="id">Masa Id'si</param>
        /// <returns>Masa</returns>
        Task<ServiceResponse<Table>> GetTable(int id);

        /// <summary>
        /// Bütün masaları getirir.
        /// </summary>
        /// <returns>Masa Listesi</returns>
        Task<ServiceResponse<IList<Table>>> GetTables();

        /// <summary>
        /// Masayı verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Masa güncelle model</param>
        /// <returns>Masa Güncellenme Durumu</returns>
        Task<ServiceResponse<bool>> UpdateTable(EditTableDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan masayı siler.
        /// </summary>
        /// <param name="id">Masa Id'si</param>
        /// <returns>Masa Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteTable(int id);
    }
}
