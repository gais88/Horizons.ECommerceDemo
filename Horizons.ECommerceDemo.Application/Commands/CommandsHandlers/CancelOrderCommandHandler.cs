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
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderDto>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CancelOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
           
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var order = await _orderService.CancelOrderAsync(request.OrderId);
                return _mapper.Map<OrderDto>(order);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
