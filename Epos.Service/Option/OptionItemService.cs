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
    public class OptionItemService : IOptionItemService
    {
        private readonly IGenericRepository<OptionItem> _optionSelectRepository;
        private readonly IOptionService _optionService;

        public OptionItemService(IGenericRepository<OptionItem> optionSelectRepository, IOptionService optionService)
        {
            _optionSelectRepository = optionSelectRepository;
            _optionService = optionService;
        }

        public async Task<ServiceResponse<OptionItem>> AddOptionSelect(AddOptionItemDTO model)
        {
            
            ServiceResponse<OptionItem> response = new ServiceResponse<OptionItem>();
            try
            {
                ServiceResponse<Option> optionResponse=await _optionService.GetOption(model.OptionId);
                if (optionResponse.data == null)
                {
                    response.message = "Option not found.";
                    return response;
                }
                   
                OptionItem optionSelect = new OptionItem
                {
                    Name=model.Name,
                    Price=model.Price,
                    LPrice=model.LPrice,
                    EPrice=model.EPrice,
                    Option=optionResponse.data,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                };
                await _optionSelectRepository.Save(optionSelect);
                response.data = optionSelect;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteOptionSelect(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var option = await _optionSelectRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
                if (option != null)
                {
                    option.IsDeleted = true;
                    option.UpdatedDate = DateTime.Now;
                    await _optionSelectRepository.Save(option);

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

        public async Task<ServiceResponse<OptionItem>> GetOptionSelect(int id)
        {
            ServiceResponse<OptionItem> response = new ServiceResponse<OptionItem>();
            try
            {
                var option = await _optionSelectRepository.Query().FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<ServiceResponse<IList<OptionItem>>> GetOptionSelects()
        {
            ServiceResponse<IList<OptionItem>> response = new ServiceResponse<IList<OptionItem>>();
            try
            {
                var options = await _optionSelectRepository.Query().ToListAsync();
                response.data = options;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
                //log
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateOptionSelect(EditOptionItemDTO model)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var optionSelect = await _optionSelectRepository.Query().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (optionSelect == null)
                    return response;
                var optionResponse = await _optionService.GetOption(model.OptionId);
                if (optionResponse.data == null)
                {
                    response.message = "Option not found.";
                    return response;
                }

                optionSelect.Name = model.Name;
                optionSelect.Price = model.Price;
                optionSelect.LPrice = model.LPrice;
                optionSelect.EPrice = model.EPrice;
                optionSelect.Option = optionResponse.data;

                optionSelect.UpdatedDate = DateTime.Now;
                await _optionSelectRepository.Save(optionSelect);

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
