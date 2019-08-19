using Bsd.Cars.Application.Orders;
using Bsd.Cars.Application.Orders.Responses;
using Bsd.Cars.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bsd.Cars.Api.Features.Inventories
{
    [ApiController]
    [ApiVersion(ApiConstants.ApiVersionV1)]
    [Route(ApiConstants.BaseApiRoute + "/Orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiConstants.AllOrders)]
        [ProducesResponseType(typeof(PaginatedResponse<OrderModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]        
        public async Task<ActionResult<PaginatedResponse<OrderModel>>> GetOrders([FromBody] GetOrdersRequest request)
        {
            var orders = await _mediator.Send(request);
            return Ok(orders);
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderModel>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdRequest { Id = id });
            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderModel>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = await _mediator.Send(request);
            return Ok(order);
        }

        [HttpPut]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateOrder([FromBody]UpdateOrderRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderRequest { Id = id });
            return NoContent();
        }
    }
}
