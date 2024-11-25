using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;

namespace RestaurantReservation.API.Presentation.Controllers
{
    /// <summary>
    /// handles all operations related to menu items.
    /// </summary>
    /// <param name="menuItemService"></param>
    [Authorize]
    [ApiController]
    [Route("api/menu-items")]
    [Produces("application/json")]
    public class MenuItemController(IMenuItemService menuItemService) : Controller
    {
        private readonly IMenuItemService _menuItemService = menuItemService;


        /// <summary>
        /// gets a list of all menu items
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of menu items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var menuItems = await _menuItemService.GetAllMenuItemsAsync(pageNumber, pageSize);
            return Ok(menuItems);
        }

        /// <summary>
        /// gets an item by id
        /// </summary>
        /// <param name="id">the id of the item</param>
        /// <returns>the item found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound($"MenuItem with ID {id} does not exist.");
            }

            return Ok(menuItem);
        }

        /// <summary>
        /// creates a new item
        /// </summary>
        /// <param name="menuItemCreateDto">the new item details</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {
            await _menuItemService.CreateMenuItemAsync(menuItemCreateDto);
            return Created();
        }

        /// <summary>
        /// updates an item 
        /// </summary>
        /// <param name="id">the id of the item to update</param>
        /// <param name="menuItemUpdateDto">the new item details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemUpdateDto menuItemUpdateDto)
        {
            var isUpdated = await _menuItemService.UpdateMenuItemAsync(id, menuItemUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"MenuItem with ID {id} does not exist.");
            }

            return Ok($"MenuItem with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes an item
        /// </summary>
        /// <param name="id">the id of the item to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            var isDeleted = await _menuItemService.DeleteMenuItemAsync(id);
            if (!isDeleted)
            {
                return NotFound($"MenuItem with ID {id} does not exist.");
            }

            return Ok($"MenuItem with ID {id} has been deleted.");
        }
    }
}
