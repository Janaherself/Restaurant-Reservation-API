using AutoMapper;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.Services
{
    public class MenuItemService(IMenuItemRepository _menuItemRepository, IMapper _mapper) : IMenuItemService
    {
        public async Task<PaginatedResult<MenuItemReadDto>> GetAllMenuItemsAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _menuItemRepository.CountAsync();
            var menuItems = await _menuItemRepository.GetAllAsync(pageNumber, pageSize);

            var menuItemDtos = _mapper.Map<List<MenuItemReadDto>>(menuItems);

            return new PaginatedResult<MenuItemReadDto>
            {
                Items = menuItemDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _menuItemRepository.GetByIdAsync(id);
        }

        public async Task CreateMenuItemAsync(MenuItemCreateDto menuItemCreateDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemCreateDto);
            await _menuItemRepository.CreateAsync(menuItem);
        }

        public async Task<bool> UpdateMenuItemAsync(int id, MenuItemUpdateDto menuItemUpdateDto)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return false;
            }

            _mapper.Map(menuItemUpdateDto, menuItem);
            await _menuItemRepository.UpdateAsync(menuItem);
            return true;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return false;
            }

            await _menuItemRepository.DeleteAsync(menuItem);
            return true;
        }
    }
}