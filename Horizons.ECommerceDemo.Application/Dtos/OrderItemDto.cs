using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Dtos
{
    public class OrderItemDto
    {
        
        public string ProductName { get; set; }
        public string ProductRef { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}