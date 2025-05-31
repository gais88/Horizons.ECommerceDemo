using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Dtos
{


    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();

        // Parameterless constructor for AutoMapper
        public OrderDto() { }
    }
}


