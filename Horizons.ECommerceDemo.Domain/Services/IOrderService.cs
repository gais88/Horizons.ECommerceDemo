using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Services
{
    public interface IOrderService
    {
        public  Task<Order> PlaceOrderAsync(Guid customerId, IEnumerable<OrderItem> items);
        public Task<Order> CancelOrderAsync(Guid orderId);
        public Task<Order> ConfirmOrderAsync(Guid orderId);
        public Task<Order> ShipOrderAsync(Guid orderId);
        public Task<Order> DeliverOrderAsync(Guid orderId);
    }
}
