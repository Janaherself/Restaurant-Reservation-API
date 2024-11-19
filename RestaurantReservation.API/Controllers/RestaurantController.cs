using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController(IRestaurantService restaurantService) : Controller
    {
        private readonly IRestaurantService _restaurantService = restaurantService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var restaurants = await _restaurantService.GetAllRestaurantsAsync(pageNumber, pageSize);
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound("Invalid Restaurant Id!");
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRestaurant(RestaurantCreateDto restaurantCreateDto)
        {
            await _restaurantService.CreateRestaurantAsync(restaurantCreateDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantUpdateDto restaurantUpdateDto)
        {
            var isUpdated = await _restaurantService.UpdateRestaurantAsync(id, restaurantUpdateDto);
            if (!isUpdated)
            {
                return BadRequest($"Restaurant with ID {id} does not exist.");
            }

            return Ok($"Restaurant with ID {id} has been updated.");
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
