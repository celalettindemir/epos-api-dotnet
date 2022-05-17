using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Service
{
    public static class ServiceRegister
    {
        public static IServiceCollection EposServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IPlaceService), typeof(PlaceService));
            services.AddScoped(typeof(ITableService), typeof(TableService));
            services.AddScoped(typeof(IStockService), typeof(StockService));
            services.AddScoped(typeof(IAllergenService), typeof(AllergenService));
            services.AddScoped(typeof(IMealService), typeof(MealService));
            services.AddScoped(typeof(IProductPortionService), typeof(ProductPortionService));
            services.AddScoped(typeof(IOptionService), typeof(OptionService));
            services.AddScoped(typeof(IOptionItemService), typeof(OptionItemService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            return services;
        }
    }
}
