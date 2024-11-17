using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/menu-items")]
    public class MenuItemController(IMenuItemService menuItemService) : Controller
    {
        private readonly IMenuItemService _menuItemService = menuItemService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound(new { Message = "Invalid Item Id!" });
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenuItem(MenuItem menuItem)
        {
            await _menuItemService.CreateMenuItemAsync(menuItem);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return BadRequest(new { message = "Invalid Item Id!" });
            }
            await _menuItemService.UpdateMenuItemAsync(menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItemAsync(id);
            return NoContent();
        }
    }
}
