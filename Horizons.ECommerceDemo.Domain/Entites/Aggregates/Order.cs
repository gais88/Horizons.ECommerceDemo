using Horizons.ECommerceDemo.Domain.Events;
using Horizons.ECommerceDemo.Domain.Exceptions;
using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using Horizons.ECommerceDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Entites.Aggregates
{
    public class Order : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get;  set; }
        public Money TotalPrice { get; private set; }

        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        private static  readonly Dictionary<OrderStatus, List<OrderStatus>> _allowedTransitions = new Dictionary<OrderStatus, List<OrderStatus>>()
        {

            [OrderStatus.Pending] = new() { OrderStatus.Confirmed, OrderStatus.Cancelled },
            [OrderStatus.Confirmed] = new() { OrderStatus.Shipped, OrderStatus.Cancelled },
            [OrderStatus.Shipped] = new() { OrderStatus.Delivered },
            [OrderStatus.Delivered] = new(),
        };
       


        public Order(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            TotalPrice = new Money(0);
          
        }

        public void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
            var price = item.Price.Amount * item.Quantity;
            TotalPrice += new Money(price);
        }
        public void SetState(OrderStatus item)
        {
            this.Status = item;
        }
        public void Confirm()
        {
            TransitionTo(OrderStatus.Confirmed);
            _domainEvents.Add(new OrderConfirmedEvent(Id));
        }

        public void Ship()
        {
            TransitionTo(OrderStatus.Shipped);
            _domainEvents.Add(new OrderShippedEvent(Id));
        }

        public void Deliver()
        {
            TransitionTo(OrderStatus.Delivered);
            _domainEvents.Add(new OrderDeliveredEvent(Id));
        }

        public void Cancel()
        {
            TransitionTo(OrderStatus.Cancelled);
            _domainEvents.Add(new OrderCancelledEvent(Id));
        }

        private void TransitionTo(OrderStatus newStatus)
        {
            try
            {
                if (!CanTransitionTo(newStatus))
                {
                    throw new InvalidOrderStateTransitionException(
                        currentStatus: Status,
                        targetStatus: newStatus,
                        orderId: Id);
                }

                Status = newStatus;
                UpdatedAt = DateTime.UtcNow;
                _domainEvents.Add(new OrderStatusChangedEvent(Id, Status));
            }
            catch (InvalidOrderStateTransitionException ex)
            {

                throw ex;
            }
           
        }

        public bool CanTransitionTo(OrderStatus newStatus)
        {
            return _allowedTransitions.TryGetValue(Status, out var allowedStatuses)
                   && allowedStatuses.Contains(newStatus);
        }
        public void PlaceOrder()
        {
            

            if (!_orderItems.Any())
            {
                throw new InvalidOperationException("Cannot place an empty order");
            }

            Status = OrderStatus.Pending;
            UpdatedAt = DateTime.UtcNow;
            _domainEvents.Add(new OrderPlacedEvent(this));
            _domainEvents.Add(new OrderStatusChangedEvent(Id, Status));
        }

        //public void Cancel()
        //{
        //    if (Status != OrderStatus.Pending && Status != OrderStatus.Confirmed)
        //    {
        //        throw new InvalidOperationException("Only placed or processing orders can be cancelled");
        //    }

        //    Status = OrderStatus.Cancelled;
        //    UpdatedAt = DateTime.UtcNow;
        //    _domainEvents.Add(new OrderCancelledEvent(this));
        //    _domainEvents.Add(new OrderStatusChangedEvent(Id, Status));
        //}

        public void ClearDomainEvents() => _domainEvents.Clear();

        // EF Core constructor
        private Order() { }
    }
}