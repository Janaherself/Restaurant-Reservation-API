using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IMenuItemService
    {
        Task CreateMenuItemAsync(MenuItemCreateDto menuItemCreateDto);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<PaginatedResult<MenuItemReadDto>> GetAllMenuItemsAsync(int pageNumber, int pageSize);
        Task<MenuItemReadDto> GetMenuItemByIdAsync(int id);
        Task<bool> UpdateMenuItemAsync(int id, MenuItemUpdateDto menuItemUpdateDto);
    }
}