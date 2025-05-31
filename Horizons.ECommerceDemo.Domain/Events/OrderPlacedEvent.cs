using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Events
{
    public class OrderPlacedEvent : IDomainEvent
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public OrderPlacedEvent(Order order)
        {
            OrderId = order.Id;
            CustomerId = order.CustomerId;
        }
    }
}