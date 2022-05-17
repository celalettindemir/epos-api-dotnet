using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using Epos.Repository;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public class TableService : ITableService
    {
        private readonly IGenericRepository<Table> _tableRepository;
        private readonly IPlaceService _placeService;

        public TableService(IGenericRepository<Table> tableRepository,
            IPlaceService placeService)
        {
            _tableRepository = tableRepository;
            _placeService = placeService;
        }

        public async Task<ServiceResponse<Table>> AddTable(AddTableDTO model)
        {
            ServiceResponse<Table> response = new ServiceResponse<Table>();
            try
            {
                var placeResponse = await _placeService.GetPlace(model.PlaceId);
                if (!placeResponse.status)
                    return response;

                Table table = new Table
                {
                    Name = model.Name,
                    Place = placeResponse.data,
                    PositionId = model.PositionId,
                    OrderId = null,
                    WaiterId = null
                };

                await _tableRepository.Save(table);

                response.data = table;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Table>> GetTable(int id)
        {
            ServiceResponse<Table> response = new ServiceResponse<Table>();
            try
            {
                var table = await _tableRepository.Query().FirstOrDefaultAsync(p => p.Id == id);

                response.data = table;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Table>>> GetTables()
        {
            ServiceResponse<IList<Table>> response = new ServiceResponse<IList<Table>>();
            try
            {
                var tables = await _tableRepository.Query().ToListAsync();

                response.data = tables;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateTable(EditTableDTO model)
        {

            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var placeResponse = await _placeService.GetPlace(model.PlaceId);
                if (!placeResponse.status)
                    return response;

                var table = await _tableRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (table == null)
                    return response;

                table.Name = model.Name;
                table.Place = placeResponse.data;
                table.PositionId = model.PositionId;

                table.UpdatedDate = DateTime.Now;
                await _tableRepository.Save(table);

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

        public async Task<ServiceResponse<bool>> DeleteTable(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var table = await _tableRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (table != null)
                {
                    table.IsDeleted = true;
                    table.UpdatedDate = DateTime.Now;
                    await _tableRepository.Save(table);

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
    }
}
