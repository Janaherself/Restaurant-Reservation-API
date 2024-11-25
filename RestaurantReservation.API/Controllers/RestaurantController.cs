using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.ServicesInterfaces;

namespace RestaurantReservation.API.Controllers
{
    /// <summary>
    /// handles all operations related to restaurants.
    /// </summary>
    /// <param name="restaurantService"></param>
    [Authorize]
    [ApiController]
    [Route("api/restaurants")]
    [Produces("application/json")]
    public class RestaurantController(IRestaurantService restaurantService) : Controller
    {
        private readonly IRestaurantService _restaurantService = restaurantService;

        /// <summary>
        /// gets a list of all restaurants
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of restaurants</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var restaurants = await _restaurantService.GetAllRestaurantsAsync(pageNumber, pageSize);
            return Ok(restaurants);
        }

        /// <summary>
        /// gets a restaurant by id
        /// </summary>
        /// <param name="id">the id of the restaurant</param>
        /// <returns>the restaurant found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound($"Restaurant with ID {id} does not exist.");
            }

            return Ok(restaurant);
        }

        /// <summary>
        /// creates a new restaurant
        /// </summary>
        /// <param name="restaurantCreateDto">the new restaurant details</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateRestaurant(RestaurantCreateDto restaurantCreateDto)
        {
            await _restaurantService.CreateRestaurantAsync(restaurantCreateDto);
            return Created();
        }

        /// <summary>
        /// updates a restaurant
        /// </summary>
        /// <param name="id">the id of the restaurant to update</param>
        /// <param name="restaurantUpdateDto">the new restaurant details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantUpdateDto restaurantUpdateDto)
        {
            var isUpdated = await _restaurantService.UpdateRestaurantAsync(id, restaurantUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Restaurant with ID {id} does not exist.");
            }

            return Ok($"Restaurant with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes a restaurant
        /// </summary>
        /// <param name="id">the id of the restaurant to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var isDeleted = await _restaurantService.DeleteRestaurantAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Restaurant with ID {id} does not exist.");
            }

            return Ok($"Restaurant with ID {id} has been deleted.");
        }
    }
}
