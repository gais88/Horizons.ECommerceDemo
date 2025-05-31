using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Shared
{
    public enum OrderStatus
    {

        Pending,    // Initial state after creation
        Confirmed,  // Payment processed, ready for fulfillment
        Shipped,    // Items shipped to customer
        Delivered,  // Order delivered (final state)
        Cancelled   // Order cancelled (final state)
    }
}
