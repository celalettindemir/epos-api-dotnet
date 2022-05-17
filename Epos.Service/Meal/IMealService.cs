using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public interface IMealService
    {

        /// <summary>
        /// Meal ekler.
        /// </summary>
        /// <param name="model">Kategori ekle modeli</param>
        /// <returns>Kategori</returns>
        Task<ServiceResponse<MealDTO>> AddMeal(AddMealDTO model);

        /// <summary>
        /// Id'si gönderilen kategoriyi getirir.
        /// </summary>
        /// <param name="id">Meal Id</param>
        /// <returns>Meal</returns>
        Task<ServiceResponse<Meal>> GetMeal(int id);

        /// <summary>
        /// Bütün meallari getirir.
        /// </summary>
        /// <returns>Meal listesi</returns>
        Task<ServiceResponse<IList<Meal>>> GetMeals();

        /// <summary>
        /// Verilen Id'ye sahip olan kategoriyi siler.
        /// </summary>
        /// <param name="id">Kategori Id'si</param>
        /// <returns>Kategori Silinme Durumu</returns>
        Task<ServiceResponse<bool>> DeleteMeal(int id);
    }
}
