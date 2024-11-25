using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IMenuItemService
    {
        Task CreateMenuItemAsync(MenuItemCreateDto menuItemCreateDto);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<PaginatedResult<MenuItemReadDto>> GetAllMenuItemsAsync(int pageNumber, int pageSize);
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task<bool> UpdateMenuItemAsync(int id, MenuItemUpdateDto menuItemUpdateDto);
    }
}