using Horizons.ECommerceDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Events
{
    public class OrderShippedEvent : IDomainEvent
    {
        public Guid OrderId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public OrderShippedEvent(Guid orderId) => OrderId = orderId;
    }
}
