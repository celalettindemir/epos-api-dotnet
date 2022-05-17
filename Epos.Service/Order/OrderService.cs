using Epos.Core.Responses;
using Epos.Domain.DTO.Model;
using Epos.Domain.Entity;
using Epos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Service
{
    public class OrderService:IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderItem> _orderItemRepository;
        //private readonly IGenericRepository<OptionItem> _optionSelectRepository;
        private readonly IProductPortionService _productPortionService;

        public OrderService(IGenericRepository<Order> orderRepository,
            IProductPortionService productPortionService,
            IGenericRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _productPortionService = productPortionService;
            _orderItemRepository = orderItemRepository;
            //_productService = productService;
            //_optionSelectRepository = optionSelectRepository;
        }

        public async Task<ServiceResponse<OrderDTO>> AddOrder(AddOrderDTO model)
        {

            ServiceResponse<OrderDTO> response = new ServiceResponse<OrderDTO>();
            try
            {
                Order order = new Order
                {
                    State = model.State,
                    Type = model.Type,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                };
                await _orderRepository.Save(order);
                var OrderDTO= new OrderDTO
                {
                    Id = order.Id,
                    State = order.State,
                    Type = order.Type,
                    orderItems = new List<OrderItemDTO>()
                };
                if (model.OrderItems!=null)
                {
                    var orderItems= new List<OrderItem>();
                    foreach (var orderItem in model.OrderItems)
                    {
                        var OrderItem = new OrderItem()
                        {
                            ProductPortion = (await _productPortionService.GetProductPortion(orderItem.ProductPortionId)).data,
                            Order = order,
                            Count = orderItem.Count
                        };
                        orderItem.TotalPrice = OrderItem.ProductPortion.Price * OrderItem.Count;
                        await _orderItemRepository.Save(OrderItem);
                        OrderDTO.orderItems.Add(new OrderItemDTO
                        {
                            Id= OrderItem.Id,
                            ProductPortion= new ProductPortionDTO
                            {
                                Id= OrderItem.ProductPortion.Id,
                                PositionId = OrderItem.ProductPortion.PositionId,
                                ProductId = OrderItem.ProductPortion.Id,
                                Color = OrderItem.ProductPortion.Color,
                                Title = OrderItem.ProductPortion.Title,
                                Price = OrderItem.ProductPortion.Price,
                            },
                            Count = orderItem.Count,
                            TotalPrice = orderItem.TotalPrice
                        });
                    }
                    OrderDTO.TotalPrice = OrderDTO.orderItems.Sum(p=>p.TotalPrice);
                }
                response.data = OrderDTO;
                /*
                foreach(var orderItem in order.OrderItems)
                {
                    response.data.orderItems.Add(new OrderItemDTO
                    {
                        Id=orderItem.Id,
                        Count=orderItem.Count,
                        TotalPrice=orderItem.TotalPrice,
                    })
                }*/
                response.status = true;
            }
            catch (Exception ex)
            {
                response.message = ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }
        /*
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
                        ProductId = option.Product != null ? option.Product.Id : 0,
                        OptionItems = new List<OptionItemDTO>()
                    };
                    foreach (var optionSelectItem in optionItems.Where(p => p.Option.Id == option.Id))
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
    */
    }
}
