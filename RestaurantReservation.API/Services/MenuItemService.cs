﻿using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class MenuItemService(IMenuItemRepository MenuItemRepository) : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository = MenuItemRepository;

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _menuItemRepository.GetByIdAsync(id);
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            // data validation goes here
            await _menuItemRepository.CreateAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            // validation
            await _menuItemRepository.UpdateAsync(menuItem);
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            // validation
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