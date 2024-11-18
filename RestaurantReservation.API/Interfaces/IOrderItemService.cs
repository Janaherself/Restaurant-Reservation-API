using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IOrderItemService
    {
        Task CreateOrderItemAsync(OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
        Task<PaginatedResult<OrderItemReadDto>> GetAllOrderItemsAsync(int pageNumber, int pageSize);
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task UpdateOrderItemAsync(OrderItem orderItem);
        Task<IEnumerable<MenuItem>>? ListOrderedMenuItemsAsync(int reservationId);    }
}