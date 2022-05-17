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
    public class AllergenService : IAllergenService
    {
        private readonly IGenericRepository<Allergen> _allergenRepository;

        public AllergenService(IGenericRepository<Allergen> allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public async Task<ServiceResponse<Allergen>> AddAllergen(AddAllergenDTO model)
        {
            ServiceResponse<Allergen> response = new ServiceResponse<Allergen>();
            try
            {
                Allergen allergen = new Allergen
                {
                    Name = model.Name,
                    Icon = model.Icon,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                };

                await _allergenRepository.Save(allergen);

                response.data = allergen;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAllergen(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var allergen = await _allergenRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (allergen != null)
                {
                    allergen.IsDeleted = true;
                    allergen.UpdatedDate = DateTime.Now;
                    await _allergenRepository.Save(allergen);

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

        public async Task<ServiceResponse<Allergen>> GetAllergen(int id)
        {
            ServiceResponse<Allergen> response = new ServiceResponse<Allergen>();
            try
            {
                var allergen = await _allergenRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                response.data = allergen;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Allergen>>> GetAllergens()
        {
            ServiceResponse<IList<Allergen>> response = new ServiceResponse<IList<Allergen>>();
            try
            {
                var allergens = await _allergenRepository.Query().ToListAsync();
                response.data = allergens;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateAllergen(EditAllergenDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var allergen = await _allergenRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (allergen == null)
                    return response;

                allergen.Name = model.Name;
                allergen.Icon = model.Icon;

                allergen.UpdatedDate = DateTime.Now;
                await _allergenRepository.Save(allergen);

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
