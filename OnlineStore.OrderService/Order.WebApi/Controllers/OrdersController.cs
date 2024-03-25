using Microsoft.AspNetCore.Mvc;
using Order.Application.Abstractions.Interfaces;
using Order.Application.DTOs.RequestDtos.Orders;

namespace Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/orders/order
        /// {
        ///     FirstName: "string"
        ///     LastName: "string"
        ///     Email: "string"
        ///     Address: "string"
        ///     Town: "string"
        ///     Comment: "string"
        ///     ProductIds: [
        ///         "string"
        ///     ]
        /// }
        /// </remarks>
        /// <returns>Order (CreateOrderResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The order failed to create</response>
        /// <response code="409">The order already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var order = await _orderService.СreateOrderAsync(roleRequestDto, cancellationToken);

            return Ok(order);
        }

        /// <summary>
        /// Gets the page of order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/orders/page?pageSize=2&pageCount=1
        /// </remarks>
        /// <param name="pageSize">int object</param>
        /// <param name="pageCount">int object</param>
        /// <returns>PageOfOrder (<IEnumerable<GetOrderPageRequesteDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpPost("page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPageAsync([FromQuery] int pageSize, [FromQuery] int pageCount, CancellationToken cancellationToken)
        {
            var pageOfOrder = await _orderService.GetOrderPageAsync(pageSize, pageCount, cancellationToken); 

            return Ok(pageOfOrder);
        }

        /// <summary>
        /// Get the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/order/65fc754df1466cc0bab12003
        /// </remarks>
        /// <param name="id">string object</param>
        /// <returns>Order (GetOrderResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The order was not found</response>
        [HttpGet("order/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);

            return Ok(order);
        }

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/order/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">string object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Order Failed to delete</response>
        /// <response code="404">The order was not found</response>
        [HttpDelete("order/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _orderService.DeleteOrderByIdAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
