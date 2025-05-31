using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands
{
    public record CancelOrderCommand(Guid OrderId) : IRequest<bool>;

}
