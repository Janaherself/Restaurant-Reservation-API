using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.API.Services;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController(IRestaurantService restaurantService) : Controller
    {
        private readonly IRestaurantService _restaurantService = restaurantService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound(new { Message = "Invalid Restaurant Id!" });
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantService.CreateRestaurantAsync(restaurant);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return BadRequest(new { Message = "Invalid Restaurant Id!" });
            }

            await _restaurantService.UpdateRestaurantAsync(restaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var isDeleted = await _restaurantService.DeleteRestaurantAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Restaurant with ID {id} does not exist.");
            }

            return Ok($"Restaurant with ID {id} has been deleted.");
        }
    }
}
