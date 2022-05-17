using Epos.Core.Responses;
using Epos.Domain.DTO;
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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductPortion> _productPortionRepository;

        private readonly ICategoryService _categoryService;

        private readonly IMealService _mealService;

        public ProductService(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductPortion> productPortionRepository,
            ICategoryService categoryService,
            IMealService mealService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _mealService = mealService;
            _productPortionRepository = productPortionRepository;
        }

        public async Task<ServiceResponse<ProductDTO>> AddProduct(AddProductDTO model)
        {
            ServiceResponse<ProductDTO> response = new ServiceResponse<ProductDTO>();
            try
            {
                var categoryResponse = await _categoryService.GetCategory(model.CategoryId);
                if (!categoryResponse.status)
                    return response;

                Product product = new Product
                {
                    Name = model.Name,
                    Category = categoryResponse.data
                };
                
                await _productRepository.Save(product);

                response.data = new ProductDTO
                {
                    Id= product.Id,
                    Name=product.Name
                };
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Product>>> GetProducts()
        {
            ServiceResponse<IList<Product>> response = new ServiceResponse<IList<Product>>();
            try
            {
                var products = await _productRepository.Query().ToListAsync();

                response.data = products;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>();
            try
            {
                var product = await _productRepository.Query().FirstOrDefaultAsync(p=>p.Id==productId);

                response.data = product;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<Product>>> GetProducts(int categoryId)
        {
            ServiceResponse<IList<Product>> response = new ServiceResponse<IList<Product>>();
            try
            {
                var products = await _productRepository.Query().ToListAsync();

                response.data = products;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IList<ProductPortion>>> GetPageProductPortions(SelectPageProductDTO model)
        {
            ServiceResponse<IList<ProductPortion>> response = new ServiceResponse<IList<ProductPortion>>();
            try
            {
                var categoryResponse = await _categoryService.GetCategory(model.CategoryId);
                if (!categoryResponse.status)
                {
                    response.message = categoryResponse.message;
                    return response;
                }
                var mealResponse = await _mealService.GetMeal(model.MealId);
                if (!mealResponse.status)
                {
                    response.message = mealResponse.message;
                    return response;
                }
                //await _productService.GetProducts(categoryId)
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<IList<CategoryProductsViewDTO>>> GetCategoryProducts()
        {
            ServiceResponse<IList<CategoryProductsViewDTO>> response = new ServiceResponse<IList<CategoryProductsViewDTO>>();
            try
            {
                var categoryResponse = await _categoryService.GetCategories();
                if (!categoryResponse.status)
                {
                    response.message = categoryResponse.message;
                    return response;
                }
                /*var productsResponse = await GetProducts();
                if (!productsResponse.status)
                {
                    response.message = productsResponse.message;
                    return response;
                }*/

                var productsPortions = await _productPortionRepository.Query().ToListAsync();
                if (productsPortions == null)
                {
                    return response;
                }
                var categoryProductsViewDTOs = new List<CategoryProductsViewDTO>();
                
                foreach (var category in categoryResponse.data)
                {
                    var categoryProductsViewDTO=new CategoryProductsViewDTO();
                    categoryProductsViewDTO.Name = category.Name;
                    categoryProductsViewDTO.Products = new List<ProductsViewDTO>();
                    
                    foreach (var product in category.products)
                    {
                        var portion = product.productPortions.FirstOrDefault(p=> p.ProductId == product.Id&& p.MealId==1);
                        if(portion!=null)
                            categoryProductsViewDTO.Products.Add(new ProductsViewDTO
                            {
                                ProductName = product.Name,
                                Price=portion.Price.ToString()
                            });
                    }
                    categoryProductsViewDTOs.Add(categoryProductsViewDTO);
                }
                response.data = categoryProductsViewDTOs;
                //await _productService.GetProducts(categoryId)
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

    }
}
