using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IOrderItemRepository
    {
        Task CreateAsync(OrderItem orderItem);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(int id);
        Task UpdateAsync(OrderItem orderItem);
        Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    }
}