using Horizons.ECommerceDemo.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.ECommerceDemo.Application.Commands
{
    public record ConfirmOrderCommand(Guid OrderId) : IRequest<bool>;
}
