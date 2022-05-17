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
    public class OptionService:IOptionService
    {
        private readonly IGenericRepository<Option> _optionRepository;
        private readonly IGenericRepository<OptionItem> _optionSelectRepository;
        private readonly IProductService _productService;

        public OptionService(IGenericRepository<Option> optionRepository,
            IProductService productService,
            IGenericRepository<OptionItem> optionSelectRepository)
        {
            _optionRepository = optionRepository;
            _productService = productService;
            _optionSelectRepository = optionSelectRepository;
        }

        public async Task<ServiceResponse<Option>> AddOption(AddOptionDTO model)
        {
            
            ServiceResponse<Option> response = new ServiceResponse<Option>();
            try
            {
                ServiceResponse<Product> productResponse;
                productResponse = await _productService.GetProduct(model.ProductId);
                Option option = new Option
                {
                    Title=model.Title,
                    Type=model.Type,
                    DefaultAll=model.DefaultAll,
                    CreatedDate = DateTime.Now,
                    Product= productResponse.data,
                    IsDeleted = false
                };

                await _optionRepository.Save(option);

                response.data = option;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteOption(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var option = await _optionRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (option != null)
                {
                    option.IsDeleted = true;
                    option.UpdatedDate = DateTime.Now;
                    await _optionRepository.Save(option);

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

        public async Task<ServiceResponse<Option>> GetOption(int id)
        {
            ServiceResponse<Option> response = new ServiceResponse<Option>();
            try
            {
                var option = await _optionRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                response.data = option;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<IList<OptionDTO>>> GetOptions()
        {
            ServiceResponse<IList<OptionDTO>> response = new ServiceResponse<IList<OptionDTO>>();
            var optionDTOs = new List<OptionDTO>();
            try
            {
                var options = await _optionRepository.Query().ToListAsync();
                var optionItems = await _optionSelectRepository.Query().ToListAsync();
                foreach (var option in options)
                {
                    var optionDTO = new OptionDTO
                    {
                        Id = option.Id,
                        Title = option.Title,
                        Type = option.Type,
                        DefaultAll = option.DefaultAll,
                        ProductId = option.Product!=null? option.Product.Id:0,
                        OptionItems = new List<OptionItemDTO>()
                    };
                    foreach (var optionSelectItem in optionItems.Where(p=>p.Option.Id==option.Id))
                    {
                        optionDTO.OptionItems.Add(new OptionItemDTO
                        {
                            Id = optionSelectItem.Id,
                            Name = optionSelectItem.Name,
                            Price = optionSelectItem.Price,
                            LPrice = optionSelectItem.LPrice,
                            EPrice = optionSelectItem.EPrice
                        });
                    }
                    optionDTOs.Add(optionDTO);
                }



                response.data = optionDTOs;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateOption(EditOptionDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var option = await _optionRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (option == null)
                    return response;
                var productResponse = await _productService.GetProduct(model.ProductId);
                option.Title = model.Title;
                option.Type = model.Type;
                option.DefaultAll = model.DefaultAll;
                option.CreatedDate = DateTime.Now;
                option.Product = productResponse.data;
                option.IsDeleted = false;

                option.UpdatedDate = DateTime.Now;
                await _optionRepository.Save(option);

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
