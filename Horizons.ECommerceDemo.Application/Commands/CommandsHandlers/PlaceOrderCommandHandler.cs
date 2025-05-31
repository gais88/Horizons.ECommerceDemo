using AutoMapper;
using Horizons.ECommerceDemo.Application.Commands;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Services;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands.CommandsHandlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, OrderDto>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public PlaceOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.Items.Select(item =>
                new OrderItem(

                    item.ProductRef,
                    item.ProductName,
                    item.Quantity,
                    new Money(item.Price, item.Currency)));

            var order = await _orderService.PlaceOrderAsync(request.CustomerId, orderItems);
            return _mapper.Map<OrderDto>(order);
        }

       
    }
}
