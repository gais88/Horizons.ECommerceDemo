using AutoMapper;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Application.Exceptions;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands.CommandsHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper    _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            await _orderRepository.DeleteAsync(result.Id);

            return _mapper.Map<OrderDto>(result);
        }
    }
}
