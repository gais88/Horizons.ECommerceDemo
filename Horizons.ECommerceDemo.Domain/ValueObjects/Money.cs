using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; } = "USD";

        public Money(decimal amount, string currency = "USD")
        {
            if (amount < 0)
            {
                throw new ArgumentException("Money amount cannot be negative", nameof(amount));
            }

            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException("Cannot add money in different currencies");
            }
            return new Money(a.Amount + b.Amount, a.Currency);
        }
    }
}