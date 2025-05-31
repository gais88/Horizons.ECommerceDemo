using Horizons.ECommerceDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Exceptions
{
    public class InvalidOrderStateTransitionException : Exception
    {
        public OrderStatus CurrentStatus { get; }
        public OrderStatus TargetStatus { get; }
        public Guid OrderId { get; }

        public InvalidOrderStateTransitionException(
            OrderStatus currentStatus,
            OrderStatus targetStatus,
            Guid orderId)
            : base($"Invalid order state transition from {currentStatus} to {targetStatus} for order {orderId}")
        {
            CurrentStatus = currentStatus;
            TargetStatus = targetStatus;
            OrderId = orderId;
        }

        // Optional: Add more constructors for different use cases
        public InvalidOrderStateTransitionException(
            OrderStatus currentStatus,
            OrderStatus targetStatus)
            : this(currentStatus, targetStatus, Guid.Empty)
        {
        }
    }
}
