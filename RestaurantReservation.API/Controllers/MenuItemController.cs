using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/menu-items")]
    public class MenuItemController(IMenuItemService menuItemService) : Controller
    {
        private readonly IMenuItemService _menuItemService = menuItemService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var menuItems = await _menuItemService.GetAllMenuItemsAsync(pageNumber, pageSize);
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound("Invalid Item Id!");
            }

            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {
            await _menuItemService.CreateMenuItemAsync(menuItemCreateDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemUpdateDto menuItemUpdateDto)
        {
            var isUpdated = await _menuItemService.UpdateMenuItemAsync(id, menuItemUpdateDto);
            if (!isUpdated)
            {
                return BadRequest($"MenuItem with ID {id} does not exist.");
            }

            return Ok($"MenuItem with ID {id} has been updated.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            var isDeleted = await _menuItemService.DeleteMenuItemAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"MenuItem with ID {id} does not exist.");
            }

            return Ok($"MenuItem with ID {id} has been deleted.");
        }
    }
}
