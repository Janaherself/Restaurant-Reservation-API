﻿using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IMenuItemRepository
    {
        Task CreateAsync(MenuItem menuItem);
        Task DeleteAsync(MenuItem menuItem);
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem> GetByIdAsync(int id);
        Task UpdateAsync(MenuItem menuItem);
    }
}