using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;

namespace RestaurantReservation.API.Presentation.Controllers
{
    /// <summary>
    /// handles all operations related to orders.
    /// </summary>
    /// <param name="_orderService"></param>
    [Authorize]
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class OrderController(IOrderService _orderService) : Controller
    {
        /// <summary>
        /// gets a list of all orders.
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of orders</returns>
        [HttpGet("orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var orders = await _orderService.GetAllOrdersAsync(pageNumber, pageSize);
            return Ok(orders);
        }

        /// <summary>
        /// gets an order by id
        /// </summary>
        /// <param name="id">the id of the order</param>
        /// <returns>>the order found, or 404 Not Found</returns>
        [HttpGet("orders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} does not exist.");
            }

            return Ok(order);
        }

        /// <summary>
        /// creates a new order
        /// </summary>
        /// <param name="orderCreateDto">the new order details</param>
        /// <returns>201 Created</returns>
        [HttpPost("orders")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateOrder(OrderCreateDto orderCreateDto)
        {
            await _orderService.CreateOrderAsync(orderCreateDto);
            return Created();
        }

        /// <summary>
        /// updates an order
        /// </summary>
        /// <param name="id">the id of the order to update</param>
        /// <param name="orderUpdateDto">the new order details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("orders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
        {
            var isUpdated = await _orderService.UpdateOrderAsync(id, orderUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Order with ID {id} does not exist.");
            }

            return Ok($"Order with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes an order
        /// </summary>
        /// <param name="id">the id of the order to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("orders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var isDeleted = await _orderService.DeleteOrderAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Order with ID {id} does not exist.");
            }

            return Ok($"Order with ID {id} has been deleted.");
        }

        /// <summary>
        /// gets the average of orders amount served by an employee
        /// </summary>
        /// <param name="employeeId">the id of the employee</param>
        /// <returns>a decimal value of the average, or 404 Not Found</returns>
        [HttpGet("employees/{employeeId}/average-order-amount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<decimal>> GetAverageOrderAmount(int employeeId)
        {
            var orderAmount = await _orderService.CalculateAverageOrderAmountAsync(employeeId);
            if (orderAmount == null)
            {
                return NotFound($"Employee with ID {employeeId} does not exist, or has not served any order.");
            }

            return Ok(orderAmount);
        }

        /// <summary>
        /// gets orders and items in each order of a reservation
        /// </summary>
        /// <param name="reservationId">the id of the reservation</param>
        /// <returns>a list of orders and items in each order, or 404 Not Found</returns>
        [HttpGet("reservations/{reservationId}/orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrdersAndMenuItemsOfReservation(int reservationId)
        {
            var orders = await _orderService.ListOrdersAndMenuItemsAsync(reservationId);
            if (orders == null)
            {
                return NotFound($"Reservation with ID {reservationId} does not exist, or has no orders.");
            }

            return Ok(orders);
        }
    }
}
