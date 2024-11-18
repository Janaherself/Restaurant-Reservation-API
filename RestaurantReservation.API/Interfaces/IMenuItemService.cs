using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IMenuItemService
    {
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<PaginatedResult<MenuItemReadDto>> GetAllMenuItemsAsync(int pageNumber, int pageSize);
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task UpdateMenuItemAsync(MenuItem menuItem);
    }
}