using Horizons.ECommerceDemo.Domain.Entites;
using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Domain.Services;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using Horizons.ECommerceDemo.Shared;
using Moq;

namespace Horizons.ECommerceDemo.UnitTest
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _orderService = new OrderService(
                _orderRepositoryMock.Object,
                _customerRepositoryMock.Object);
        }

        [Fact]
        public async Task PlaceOrderAsync_WithValidCustomer_CreatesOrder()
        {
            // Arrange
           
            var customer = new Customer("Test Customer", new Email("test@example.com"));
            var items = new List<OrderItem>
        {
            new("1234567", "Product 1", 2, new Money(10)),
            new("4332234", "Product 2", 1, new Money(20))
        };

            _customerRepositoryMock.Setup(r => r.GetByIdAsync(customer.Id))
                                   .ReturnsAsync(customer);
            
            _orderRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Order>()))
                               .Returns(Task.CompletedTask);

            // Act
            var order = await _orderService.PlaceOrderAsync(customer.Id, items);

            // Assert
            Assert.NotNull(order);
            Assert.Equal(customer.Id, order.CustomerId);
            Assert.Equal(OrderStatus.Pending, order.Status);
            Assert.Equal(40, order.TotalPrice.Amount);
            Assert.Equal(2, order.OrderItems.Count);
        }
    }
}