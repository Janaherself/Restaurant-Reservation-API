﻿using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class OrderItemService(IOrderItemRepository OrderItemRepository) : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository = OrderItemRepository;

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            // data validation goes here
            await _orderItemRepository.CreateAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            // validation
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            // validation
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
                return false;
            }

            await _orderItemRepository.DeleteAsync(orderItem);
            return true;
        }

        public async Task<IEnumerable<MenuItem>>? ListOrderedMenuItemsAsync(int reservationId)
        {
            var menuItems = await _orderItemRepository.ListOrderedMenuItemsAsync(reservationId);
            if (!menuItems.Any())
            {
                return null;
            }
            return menuItems;
        }
    }
}