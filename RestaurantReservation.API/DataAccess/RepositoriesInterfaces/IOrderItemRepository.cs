using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.DataAccess.RepositoriesInterfaces
{
    public interface IOrderItemRepository
    {
        Task CreateAsync(OrderItem orderItem);
        Task DeleteAsync(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> GetAllAsync(int pageNumber, int pageSize);
        Task<OrderItem> GetByIdAsync(int id);
        Task UpdateAsync(OrderItem orderItem);
        Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
        Task<int> CountAsync();
    }
}