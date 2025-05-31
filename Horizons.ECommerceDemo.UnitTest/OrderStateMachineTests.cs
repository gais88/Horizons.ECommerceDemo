using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.Events;
using Horizons.ECommerceDemo.Domain.Exceptions;
using Horizons.ECommerceDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.UnitTest
{
    public class OrderStateMachineTests
    {
        [Theory]
        [InlineData(OrderStatus.Pending, OrderStatus.Confirmed, true)]
        [InlineData(OrderStatus.Pending, OrderStatus.Cancelled, true)]
        [InlineData(OrderStatus.Confirmed, OrderStatus.Shipped, true)]
        [InlineData(OrderStatus.Confirmed, OrderStatus.Cancelled, true)]
        [InlineData(OrderStatus.Shipped, OrderStatus.Delivered, true)]
        [InlineData(OrderStatus.Delivered, OrderStatus.Cancelled, false)]
        [InlineData(OrderStatus.Cancelled, OrderStatus.Confirmed, false)]
        public void CanTransition_ValidatesCorrectly(OrderStatus from, OrderStatus to, bool expected)
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            SetOrderStatus(order, from);

            // Act
            var canTransition = order.CanTransitionTo(to);

            // Assert
            Assert.Equal(expected, canTransition);
        }

        [Fact]
        public void Confirm_PendingOrder_TransitionsToConfirmed()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());

            // Act
            order.Confirm();

            // Assert
            Assert.Equal(OrderStatus.Confirmed, order.Status);
            Assert.Single(order.DomainEvents.OfType<OrderConfirmedEvent>());
        }

        [Fact]
        public void Confirm_ShippedOrder_ThrowsException()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            SetOrderStatus(order, OrderStatus.Shipped);

            // Act & Assert
            Assert.Throws<InvalidOrderStateTransitionException>(() => order.Confirm());
        }

        private void SetOrderStatus(Order order, OrderStatus status)
        {
           
            order.SetState(status);
        }
    }
}