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
    public class ShipOrderCommandHandler : IRequestHandler<ShipOrderCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;
        

        public ShipOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

       

        public async Task<bool> Handle(ShipOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var order = await _orderRepository.GetByIdAsync(request.OrderId);
                if (order == null) throw new ArgumentException("Order not found");

                order.Ship();
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
