using AutoMapper;
using Horizons.ECommerceDemo.Application.Commands;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands.CommandsHandlers
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand,OrderDto>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;


        public ConfirmOrderCommandHandler(
          IMapper mapper,
          IOrderService orderService)
        {
          
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<OrderDto> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var order = await _orderService.ConfirmOrderAsync(request.OrderId);
                return _mapper.Map<OrderDto>(order);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
