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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductPortion> _productPortionRepository;
        private readonly IGenericRepository<Meal> _mealRepository;
        private readonly IGenericRepository<CategoryMeal> _categoryMealRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductPortion> productPortionRepository,
            IGenericRepository<Meal> mealRepository,
            IGenericRepository<CategoryMeal> categoryMealRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productPortionRepository = productPortionRepository;
            _mealRepository = mealRepository;
            _categoryMealRepository = categoryMealRepository;
        }

        public async Task<ServiceResponse<CategoryDTO>> AddCategory(AddCategoryDTO model)
        {
            ServiceResponse<CategoryDTO> response = new ServiceResponse<CategoryDTO>();
            try
            {
                Category category = new Category
                {
                    ButtonWidth = model.ButtonWidth,
                    Name = model.Name
                };

                await _categoryRepository.Save(category);


                response.data = new CategoryDTO
                {
                    Id=category.Id,
                    Name=category.Name,
                    ButtonWidth=category.ButtonWidth
                };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Category>> GetCategory(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            try
            {
                var category = await _categoryRepository.Query().Fetch(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<ServiceResponse<IList<CategoryDTO>>> GetCategories()
        {
            ServiceResponse<IList<CategoryDTO>> response = new ServiceResponse<IList<CategoryDTO>>();
            try
            {
                var categories = await _categoryRepository.Query().ToListAsync();
                if (categories == null)
                    return response;
                var products = await _productRepository.Query().ToListAsync();
                if (products==null)
                    return response;
                var productPortions = await _productPortionRepository.Query().ToListAsync();
                if (productPortions == null)
                    return response;
                var categoryMeals = await _categoryMealRepository.Query().ToListAsync();
                if (categoryMeals == null)
                    return response;
                var categoryDTOList = new List<CategoryDTO>();
                foreach (var category in categories)
                {
                    var categoryDTO = new CategoryDTO
                    {
                        Id = category.Id,
                        Name = category.Name,
                        products = new List<ProductDTO>(),
                        MealsID = new List<int>()
                    };
                    foreach (var product in products.Where(p => p.Category.Id == category.Id))
                    {
                        var ProductDTO = new ProductDTO
                        {
                            CategoryId = category.Id,
                            Id = product.Id,
                            Name = product.Name,
                            productPortions = new List<ProductPortionDTO>()
                        };
                        foreach (var productPortion in productPortions.Where(p => p.Product.Id == product.Id))
                        {
                            ProductDTO.productPortions.Add(new ProductPortionDTO
                            {
                                Id= productPortion.Id,
                                MealId = productPortion.Meal.Id,
                                Price = productPortion.Price,
                                PositionId = productPortion.PositionId,
                                ProductId = productPortion.Product.Id,
                                Color=productPortion.Color,
                                Title=productPortion.Title
                            });
                        }
                        categoryDTO.products.Add(ProductDTO);
                    }
                    foreach(var meal in categoryMeals.Where(p => p.Category.Id == category.Id))
                    {
                        categoryDTO.MealsID.Add(meal.Meal.Id);
                    }
                    categoryDTOList.Add(categoryDTO);
                }
                response.data = categoryDTOList;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateCategory(EditCategoryDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var category = await _categoryRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (category == null)
                    return response;

                category.Name = model.Name;
                category.ButtonWidth = model.ButtonWidth;

                category.UpdatedDate = DateTime.Now;
                await _categoryRepository.Save(category);

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

        public async Task<ServiceResponse<bool>> DeleteCategory(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var category = await _categoryRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                {
                    category.IsDeleted = true;
                    category.UpdatedDate = DateTime.Now;
                    await _categoryRepository.Save(category);

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
