using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class MenuItemService(IMenuItemRepository MenuItemRepository, IMapper mapper) : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository = MenuItemRepository;
        private readonly IMapper _mapper = mapper;

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

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.CreateAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.UpdateAsync(menuItem);
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