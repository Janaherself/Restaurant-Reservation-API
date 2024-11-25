using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.ServicesInterfaces;

namespace RestaurantReservation.API.Controllers
{
    /// <summary>
    /// handles all operations related to order items.
    /// </summary>
    /// <param name="orderItemService"></param>
    [Authorize]
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class OrderItemController(IOrderItemService orderItemService) : Controller
    {
        private readonly IOrderItemService _orderItemService = orderItemService;

        /// <summary>
        /// gets a list of all order items
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of order items</returns>
        [HttpGet("order-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var orderItems = await _orderItemService.GetAllOrderItemsAsync(pageNumber, pageSize);
            return Ok(orderItems);
        }

        /// <summary>
        /// gets an item by id
        /// </summary>
        /// <param name="id">the id of the item</param>
        /// <returns>the item found, or 404 Not Found</returns>
        [HttpGet("order-items/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound($"OrderItem with ID {id} does not exist.");
            }

            return Ok(orderItem);
        }

        /// <summary>
        /// creates a new item
        /// </summary>
        /// <param name="orderItemCreateDto">the new item details</param>
        /// <returns>201 Created</returns>
        [HttpPost("order-items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateOrderItem(OrderItemCreateDto orderItemCreateDto)
        {
            await _orderItemService.CreateOrderItemAsync(orderItemCreateDto);
            return Created();
        }

        /// <summary>
        /// updates an item
        /// </summary>
        /// <param name="id">the id of the item to update</param>
        /// <param name="orderItemUpdateDto">the new item details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("order-items/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var isUpdated = await _orderItemService.UpdateOrderItemAsync(id, orderItemUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"OrderItem with ID {id} does not exist.");
            }

            return Ok($"OrderItem with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes an item
        /// </summary>
        /// <param name="id">the id of the item to delete</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpDelete("order-items/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteOrderItem(int id)
        {
            var isDeleted = await _orderItemService.DeleteOrderItemAsync(id);
            if (!isDeleted)
            {
                return NotFound($"OrderItem with ID {id} does not exist.");
            }

            return Ok($"OrderItem with ID {id} has been deleted.");
        }

        /// <summary>
        /// gets all the ordered items in a reservation
        /// </summary>
        /// <param name="reservationId">the reservation id</param>
        /// <returns>a list of ordered items, or 404 Not Found</returns>
        [HttpGet("reservations/{reservationId}/menu-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetOrderedMenuItemsOfReservation(int reservationId)
        {
            var menuItems = await _orderItemService.ListOrderedMenuItemsAsync(reservationId);
            if (menuItems == null)
            {
                return NotFound($"Reservation with ID {reservationId} either does not exist, or has no ordered items.");
            }

            return Ok(menuItems);
        }
    }
}
