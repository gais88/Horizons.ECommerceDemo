using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Order> PlaceOrderAsync(Guid customerId, IEnumerable<OrderItem> items)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new ArgumentException("Customer not found", nameof(customerId));
            }

            var order = new Order(customerId);
            foreach (var item in items)
            {
                order.AddItem(item);
            }

            order.PlaceOrder();
            await _orderRepository.AddAsync(order);

            return order;
        }

        public async Task<Order> CancelOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found", nameof(orderId));
            }

            order.Cancel();
            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<Order> ConfirmOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found", nameof(orderId));
            }

            order.Confirm();
            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<Order> ShipOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found", nameof(orderId));
            }

            order.Ship();
            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<Order> DeliverOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found", nameof(orderId));
            }

            order.Deliver();
            await _orderRepository.UpdateAsync(order);
            return order;
        }
    }
}