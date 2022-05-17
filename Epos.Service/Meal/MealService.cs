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
    public class MealService : IMealService
    {
        private readonly IGenericRepository<Meal> _mealRepository;

        public MealService(IGenericRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<ServiceResponse<MealDTO>> AddMeal(AddMealDTO model)
        {
            ServiceResponse<MealDTO> response = new ServiceResponse<MealDTO>();
            try
            {
                Meal meal = new Meal
                {
                    ButtonWidth = model.ButtonWidth,
                    Name = model.Name
                };

                await _mealRepository.Save(meal);

                response.data = new MealDTO
                {
                    Id=meal.Id,
                    Name=meal.Name
                };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Meal>> GetMeal(int id)
        {
            ServiceResponse<Meal> response = new ServiceResponse<Meal>();
            try
            {
                var category = await _mealRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                response.data = category;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Meal>>> GetMeals()
        {
            ServiceResponse<IList<Meal>> response = new ServiceResponse<IList<Meal>>();
            try
            {
                var categories = await _mealRepository.Query().ToListAsync();
                response.data = categories;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> DeleteMeal(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var meal = await _mealRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (meal != null)
                {
                    meal.IsDeleted = true;
                    meal.UpdatedDate = DateTime.Now;
                    await _mealRepository.Save(meal);

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
