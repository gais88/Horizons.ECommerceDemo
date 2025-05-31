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
        public Task CancelOrderAsync(Guid orderId);
    }
}
