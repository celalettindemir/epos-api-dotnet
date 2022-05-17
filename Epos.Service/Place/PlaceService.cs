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
    public class PlaceService : IPlaceService
    {
        private readonly IGenericRepository<Place> _placeRepository;

        public PlaceService(IGenericRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<ServiceResponse<Place>> AddPlace(AddPlaceDTO model)
        {
            ServiceResponse<Place> response = new ServiceResponse<Place>();
            try
            {
                Place place = new Place
                {
                    Name = model.name
                };
                await _placeRepository.Save(place);

                response.status = true;
                response.data = place;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<Place>> GetPlace(int Id)
        {
            ServiceResponse<Place> response = new ServiceResponse<Place>();
            try
            {
                response.data = await _placeRepository.Query().Fetch(p => p.Tables).FirstOrDefaultAsync(p => p.Id == Id);
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Place>>> GetPlaces()
        {
            ServiceResponse<IList<Place>> response = new ServiceResponse<IList<Place>>();
            try
            {
                response.data = await _placeRepository.Query().Fetch(p => p.Tables).ToListAsync();
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdatePlace(EditPlaceDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var place = await _placeRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (place != null)
                {
                    place.Name = model.Name;
                    place.UpdatedDate = DateTime.Now;
                    await _placeRepository.Save(place);

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

        public async Task<ServiceResponse<bool>> DeletePlace(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var place = await _placeRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (place != null)
                {
                    place.IsDeleted = true;
                    place.UpdatedDate = DateTime.Now;
                    await _placeRepository.Save(place);

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
