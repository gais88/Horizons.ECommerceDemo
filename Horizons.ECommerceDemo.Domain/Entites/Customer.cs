using Horizons.ECommerceDemo.Domain.Entites.Aggregates;
using Horizons.ECommerceDemo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Entites
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }

        private readonly List<Order> _orders = new();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        public Customer(string name, Email email)
        {
            Id = Guid.NewGuid();
            SetName(name);
            Email = email;
        }

        // EF Core constructor
        private Customer():base() { }

        private void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

    }
}
