using Horizons.ECommerceDemo.Application.Commands;
using Horizons.ECommerceDemo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands.CommandsHandlers
{
    public record DeliverOrderCommandHandler : IRequestHandler<DeliverOrderCommand,bool>
    {
        private readonly IOrderRepository _orderRepository ;

        public DeliverOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
               

                    var order = await _orderRepository.GetByIdAsync(request.OrderId);
                    if (order == null) throw new ArgumentException("Order not found");

                    order.Deliver();
                    await _orderRepository.UpdateAsync(order);
                    return true;
               
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
