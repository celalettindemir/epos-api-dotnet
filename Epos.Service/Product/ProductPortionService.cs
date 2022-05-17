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
    public class ProductPortionService : IProductPortionService
    {
        private readonly IGenericRepository<ProductPortion> _productPortionRepository;
        private readonly IProductService _productService;
        private readonly IMealService _mealService;
        private readonly ICategoryService _categoryService;

        public ProductPortionService(IGenericRepository<ProductPortion> productPortionRepository,
            IProductService productService,
            IMealService mealService,
            ICategoryService categoryService)
        {
            _productPortionRepository = productPortionRepository;
            _productService = productService;
            _mealService = mealService;
            _categoryService = categoryService;
        }/*
        public async Task<ServiceResponse<ProductPortion>> GetProductPortion(int mealId)
        {
            ServiceResponse<ProductPortion> response = new ServiceResponse<ProductPortion>();
            try
            {
                var mealResponse = await _productService.GetProduct(model.ProductId);
                if (!productResponse.status)
                {
                    response.message = productResponse.message;
                    return response;
                }
                var mealResponse = await _mealService.GetMeal(model.MealId);
                if (!mealResponse.status)
                {
                    response.message = mealResponse.message;
                    return response;
                }
                //İlk defa eklenme durumunda categoryMeals'a ekleniyor Meal
                if (!productResponse.data.Category.CategoryMeals.Any(p => p.Meal == mealResponse.data))
                    productResponse.data.Category.CategoryMeals.Add(new CategoryMeal { Meal = mealResponse.data, Category = productResponse.data.Category });

                ProductPortion productPortion = new ProductPortion
                {
                    Color = model.Color,
                    Title = model.Title,
                    Price = model.Price,
                    PositionId = model.PositionId,
                    Product = productResponse.data,
                    Meal = mealResponse.data
                };

                await _productPortionRepository.Save(productPortion);

                response.data = new ProductPortion { Id = productPortion.Id };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }*/
        public async Task<ServiceResponse<ProductPortionDTO>> AddProductPortion(AddProductPortionDTO model)
        {
            ServiceResponse<ProductPortionDTO> response = new ServiceResponse<ProductPortionDTO>();
            try
            {
                var productResponse = await _productService.GetProduct(model.ProductId);
                if (!productResponse.status)
                {
                    response.message = productResponse.message;
                    return response;
                }
                var mealResponse = await _mealService.GetMeal(model.MealId);
                if (!mealResponse.status)
                {
                    response.message = mealResponse.message;
                    return response;
                }
                //İlk defa eklenme durumunda categoryMeals'a ekleniyor Meal
                if (!productResponse.data.Category.CategoryMeals.Any(p=>p.Meal== mealResponse.data))
                    productResponse.data.Category.CategoryMeals.Add(new CategoryMeal { Meal = mealResponse.data, Category = productResponse.data.Category });

                ProductPortion productPortion = new ProductPortion
                {
                    Color = model.Color,
                    Title = model.Title,
                    Price = model.Price,
                    PositionId = model.PositionId,
                    Product=productResponse.data,
                    Meal=mealResponse.data
                };
                
                await _productPortionRepository.Save(productPortion);

                response.data = new ProductPortionDTO{ 
                    Id=productPortion.Id,
                    Color = productPortion.Color,
                    Title = productPortion.Title,
                    Price = productPortion.Price,
                    PositionId = productPortion.PositionId,
                    MealId= mealResponse.data.Id,
                    ProductId=productResponse.data.Id

                };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<ProductPortion>> GetProductPortion(int Id)
        {
            ServiceResponse<ProductPortion> response = new ServiceResponse<ProductPortion>();
            try
            {
                var productPortion = await _productPortionRepository.Query().FirstOrDefaultAsync(p=>p.Id== Id);
                if (productPortion == null)
                {
                    return response;
                }
                response.data = productPortion;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<List<ProductPortion>>> GetProductPortions()
        {
            ServiceResponse<List<ProductPortion>> response = new ServiceResponse<List<ProductPortion>>();
            try
            {
                var productPortions = await _productPortionRepository.Query().ToListAsync();
                if (productPortions == null)
                {
                    return response;
                }
                response.data = productPortions;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<ProductPortionDTO>> UpdateProductPortion(ProductPortionDTO model)
        {
            ServiceResponse<ProductPortionDTO> response = new ServiceResponse<ProductPortionDTO>();
            try
            {
                var productResponse = await _productService.GetProduct(model.ProductId);
                if (!productResponse.status)
                {
                    response.message = productResponse.message;
                    return response;
                }
                var mealResponse = await _mealService.GetMeal(model.MealId);
                if (!mealResponse.status)
                {
                    response.message = mealResponse.message;
                    return response;
                }
                var productPortion = await _productPortionRepository.Query().FirstAsync(p=>p.Id==model.Id);
                if (productPortion==null)
                    productPortion = new ProductPortion();
                //İlk defa eklenme durumunda categoryMeals'a ekleniyor Meal
                if (!productResponse.data.Category.CategoryMeals.Any(p => p.Meal == mealResponse.data))
                    productResponse.data.Category.CategoryMeals.Add(new CategoryMeal { Meal = mealResponse.data, Category = productResponse.data.Category });

                productPortion.Color = model.Color;
                productPortion.Title = model.Title;
                productPortion.Price = model.Price;
                productPortion.PositionId = model.PositionId;
                productPortion.Product = productResponse.data;
                productPortion.Meal = mealResponse.data;

                await _productPortionRepository.Save(productPortion);

                response.data = new ProductPortionDTO
                {
                    Id = productPortion.Id,
                    Color = productPortion.Color,
                    Title = productPortion.Title,
                    Price = productPortion.Price,
                    PositionId = productPortion.PositionId,
                    MealId = mealResponse.data.Id,
                    ProductId = productResponse.data.Id

                };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

    }
}
