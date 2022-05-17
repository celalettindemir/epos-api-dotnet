using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IStockService
    {
        /// <summary>
        /// Stok ekler.
        /// </summary>
        /// <param name="model">Stok ekleme modeli</param>
        /// <returns>Eklenen <see cref="Stock"/></returns>
        Task<ServiceResponse<Stock>> AddStock(AddStockDTO model);

        /// <summary>
        /// Stok kaydı ekler.
        /// </summary>
        /// <param name="model">Stok kaydı ekleme modeli</param>
        /// <returns>Eklenen <see cref="StockTransaction"/></returns>
        Task<ServiceResponse<StockTransaction>> AddStockTransaction(AddStockTransactionDTO model);

        /// <summary>
        /// Id'si verilen stoğu getirir
        /// </summary>
        /// <param name="id">Stok id</param>
        /// <returns><see cref="Stock"/></returns>
        Task<ServiceResponse<Stock>> GetStock(int id);

        /// <summary>
        /// Bütün stokları getirir.
        /// </summary>
        /// <returns><see cref="IList{Stock}"/></returns>
        Task<ServiceResponse<IList<Stock>>> GetStocks();

        /// <summary>
        /// Bütün stok kayıtlarını getirir.
        /// </summary>
        /// <returns><see cref="IList{StockTransaction}"/></returns>
        Task<ServiceResponse<IList<StockTransaction>>> GetStockTransactions();

        /// <summary>
        /// Stok Id'si verilen tüm stok kayıtlarını getirir.
        /// </summary>
        /// <param name="stockId">Stok Id</param>
        /// <returns><see cref="IList{StockTransaction}"/></returns>
        Task<ServiceResponse<IList<StockTransaction>>> GetStockTransactions(int stockId);

        /// <summary>
        /// Stoğu verilen bilgilere göre günceller.
        /// </summary>
        /// <param name="model">Stok güncelleme modeli</param>
        /// <returns><see cref="Stock"/> güncelleme durumu</returns>
        Task<ServiceResponse<bool>> UpdateStock(EditStockDTO model);

        /// <summary>
        /// Verilen Id'ye sahip olan stoğu siler.
        /// </summary>
        /// <param name="id">Stock Id'si</param>
        /// <returns><see cref="Stock"/> Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteStock(int id);
    }
}
