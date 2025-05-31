using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Domain.Exceptions
{
    public class OrderDomainException: Exception
    {
        public OrderDomainException(string message) : base(message) { }
        public OrderDomainException(string message, Exception inner) : base(message, inner) { }
    }
}
