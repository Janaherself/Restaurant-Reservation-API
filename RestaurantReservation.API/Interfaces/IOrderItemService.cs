using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IOrderItemService
    {
        Task CreateOrderItemAsync(OrderItem orderItem);
        Task DeleteOrderItemAsync(int id);
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task UpdateOrderItemAsync(OrderItem orderItem);
        Task<IEnumerable<MenuItem>>? ListOrderedMenuItemsAsync(int reservationId);    }
}