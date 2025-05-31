using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Events
{
    public class OrderStatusChangedEvent : IDomainEvent
    {
        public Guid OrderId { get; }
        public OrderStatus NewStatus { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public OrderStatusChangedEvent(Guid orderId, OrderStatus newStatus)
        {
            OrderId = orderId;
            NewStatus = newStatus;
        }
    }
}