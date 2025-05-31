using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Entites
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public string ProductRef { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }

        public Order Order { get; private set; }
        public Guid OrderId { get; private set; }

        public OrderItem(string productRef, string productName, int quantity, Money price)
        {
            Id = Guid.NewGuid();
            ProductRef = productRef;
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive", nameof(quantity));
            Price = price;
        }

        // EF Core constructor
        private OrderItem() { }

       
    }
}
