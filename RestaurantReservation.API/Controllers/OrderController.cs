using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class OrderController(IOrderService orderService) : Controller
    {
        private readonly IOrderService _orderService = orderService;


        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { Message = "Invalid Order Id!" });
            }
            return Ok(order);
        }

        [HttpPost("orders")]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            await _orderService.CreateOrderAsync(order);
            return Created();
        }

        [HttpPut("orders/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest(new { message = "Invalid Order Id!" });
            }
            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("orders/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var isDeleted = await _orderService.DeleteOrderAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Order with ID {id} does not exist.");
            }

            return Ok($"Order with ID {id} has been deleted.");
        }

        [HttpGet("employees/{employeeId}/average-order-amount")]
        public async Task<ActionResult<decimal>> GetAverageOrderAmount(int employeeId)
        {
            var orderAmount = await _orderService.CalculateAverageOrderAmountAsync(employeeId);
            return Ok(orderAmount);
        }

        [HttpGet("reservations/{reservationId}/orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAndMenuItemsOfReservation(int reservationId)
        {
            var orders = await _orderService.ListOrdersAndMenuItemsAsync(reservationId);
            if (orders == null)
            {
                return BadRequest(new { message = "Invalid Reservation Id!" });
            }
            return Ok(orders);
        }
    }
}
