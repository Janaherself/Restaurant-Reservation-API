using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class OrderItemController(IOrderItemService orderItemService) : Controller
    {
        private readonly IOrderItemService _orderItemService = orderItemService;


        [HttpGet("order-items")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpGet("order-items/{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound("Invalid OrderItem Id!");
            }
            return Ok(orderItem);
        }

        [HttpPost("order-items")]
        public async Task<ActionResult> CreateOrderItem(OrderItem orderItem)
        {
            await _orderItemService.CreateOrderItemAsync(orderItem);
            return Created();
        }

        [HttpPut("order-items/{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.OrderItemId)
            {
                return BadRequest("Invalid OrderItem Id!");
            }
            await _orderItemService.UpdateOrderItemAsync(orderItem);
            return NoContent();
        }

        [HttpDelete("order-items/{id}")]
        public async Task<ActionResult> DeleteOrderItem(int id)
        {
            var isDeleted = await _orderItemService.DeleteOrderItemAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"OrderItem with ID {id} does not exist.");
            }

            return Ok($"OrderItem with ID {id} has been deleted.");
        }

        [HttpGet("reservations/{reservationId}/menu-items")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetOrderedMenuItemsOfReservation(int reservationId)
        {
            var menuItems = await _orderItemService.ListOrderedMenuItemsAsync(reservationId);
            if (menuItems == null)
            {
                return BadRequest("Invalid Reservation Id!");
            }
            return Ok(menuItems);
        }
    }
}
