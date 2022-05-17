using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using Epos.Repository;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public class StockService : IStockService
    {
        private readonly IGenericRepository<Stock> _stockRepository;
        private readonly IGenericRepository<StockTransaction> _stockTransactionRepository;

        public StockService(IGenericRepository<Stock> stockRepository,
            IGenericRepository<StockTransaction> stockTransactionRepository)
        {
            _stockRepository = stockRepository;
            _stockTransactionRepository = stockTransactionRepository;
        }

        public async Task<ServiceResponse<Stock>> AddStock(AddStockDTO model)
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                Stock stock = new Stock
                {
                    Amount = model.Amount,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Name = model.Name,
                    Type = model.Type
                };

                await _stockRepository.Save(stock);

                response.data = stock;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<StockTransaction>> AddStockTransaction(AddStockTransactionDTO model)
        {
            ServiceResponse<StockTransaction> response = new ServiceResponse<StockTransaction>();
            try
            {
                var stockResponse = await GetStock(model.StockId);
                if (!stockResponse.status)
                {
                    response.message = "Hatalı stock numarası.";
                    return response;
                }

                StockTransaction stockTransaction = new StockTransaction
                {
                    Amount = model.Amount,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Description = model.Description,
                    Stock = stockResponse.data,
                };

                await _stockTransactionRepository.Save(stockTransaction);

                //Stoğa eklenir
                var stock = stockResponse.data;
                stock.Amount += model.Amount;
                await _stockRepository.Save(stock);

                response.data = stockTransaction;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteStock(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var stock = await _stockRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (stock != null)
                {
                    stock.IsDeleted = true;
                    stock.UpdatedDate = DateTime.Now;
                    await _stockRepository.Save(stock);

                    response.data = true;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<Stock>> GetStock(int id)
        {
            ServiceResponse<Stock> response = new ServiceResponse<Stock>();
            try
            {
                var stock = await _stockRepository.Query().FirstOrDefaultAsync(p => p.Id == id);

                response.data = stock;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Stock>>> GetStocks()
        {
            ServiceResponse<IList<Stock>> response = new ServiceResponse<IList<Stock>>();
            try
            {
                var stocks = await _stockRepository.Query().ToListAsync();

                response.data = stocks;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<StockTransaction>>> GetStockTransactions()
        {
            ServiceResponse<IList<StockTransaction>> response = new ServiceResponse<IList<StockTransaction>>();
            try
            {
                var stockTransactions = await _stockTransactionRepository.Query().ToListAsync();

                response.data = stockTransactions;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<StockTransaction>>> GetStockTransactions(int stockId)
        {
            ServiceResponse<IList<StockTransaction>> response = new ServiceResponse<IList<StockTransaction>>();
            try
            {
                var stock = await GetStock(stockId);
                if (!stock.status)
                {
                    response.message = "Hatalı stock numarası.";
                    return response;
                }

                var stockTransaction = await _stockTransactionRepository.Query().Where(p => p.Stock.Id == stockId).ToListAsync();

                response.data = stockTransaction;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateStock(EditStockDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var stock = await _stockRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (stock == null)
                    return response;

                stock.Name = model.Name;
                stock.Amount = model.Amount;
                stock.Type = model.Type;

                stock.UpdatedDate = DateTime.Now;
                await _stockRepository.Save(stock);

                response.data = true;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }
    }
}
