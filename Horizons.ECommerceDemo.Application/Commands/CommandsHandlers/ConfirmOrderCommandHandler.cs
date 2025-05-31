using AutoMapper;
using Horizons.ECommerceDemo.Application.Commands;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands.CommandsHandlers
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public ConfirmOrderCommandHandler(
            IOrderRepository orderRepository
,           IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {

            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null) throw new ArgumentException("Order not found");

                order.Confirm();
             await _orderRepository.UpdateAsync(order);
                return  true;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
