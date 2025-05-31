using Horizons.ECommerceDemo.Application.Commands;
using Horizons.ECommerceDemo.Application.Commands.CommandsHandlers;
using Horizons.ECommerceDemo.Application.Dtos;
using Horizons.ECommerceDemo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Horizons.ECommerceDemo.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetById/{id:Guid}")]
        public async Task<ActionResult<OrderDto>> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery() { Id = id };
            var result = await _mediator.Send(query);

            return result;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<OrderDto>> Create(PlaceOrderCommand PlaceOrderCommand)
        {
            var result = await _mediator.Send(PlaceOrderCommand);

            return result;
        }
        [HttpPost("ConfirmOrder/{id:Guid}")]
        public async Task<ActionResult<bool>> ConfirmOrder(Guid id)
        {
            var comamand = new ConfirmOrderCommand(id);
            var result = await _mediator.Send(comamand);
            return result;
        }
        [HttpPost("CancelOrder/{id:Guid}")]
        public async Task<ActionResult<bool>> CancelOrder(Guid id)
        {
            var comamand = new CancelOrderCommand(id);
            var result = await _mediator.Send(comamand);
            return result;
        }
        [HttpPost("DeliverOrderC/{id:Guid}")]
        public async Task<ActionResult<bool>> DeliverOrderC(Guid id)
        {
            var comamand = new DeliverOrderCommand(id);
            var result = await _mediator.Send(comamand);
            return result;
        }
        [HttpPost("ShipOrderC/{id:Guid}")]
        public async Task<ActionResult<bool>> ShipOrderC(Guid id)
        {
            var comamand = new ShipOrderCommand(id);
            var result = await _mediator.Send(comamand);
            return result;
        }


        [HttpDelete("Delete/{id:Guid}")]
        public async Task<ActionResult<OrderDto>> Delete(Guid id)
        {
            var query = new DeleteOrderCommand() { Id = id };
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
