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

namespace Horizons.ECommerceDemo.Application.Queries.QueriesHandlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDto>(result);
        }
    }
}
