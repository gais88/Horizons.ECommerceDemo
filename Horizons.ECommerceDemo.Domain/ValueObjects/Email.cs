using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            {
                throw new ArgumentException("Invalid email address", nameof(value));
            }
            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;
        public static explicit operator Email(string value) => new(value);
    }
}
