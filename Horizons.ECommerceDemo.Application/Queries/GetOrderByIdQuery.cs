using Horizons.ECommerceDemo.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Queries
{
    public class GetOrderByIdQuery:IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
