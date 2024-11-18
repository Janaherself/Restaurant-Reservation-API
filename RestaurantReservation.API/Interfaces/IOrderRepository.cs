using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync(int pageNumber, int pageSize);
        Task<Order> GetByIdAsync(int id);
        Task UpdateAsync(Order order);
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
        Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
        Task<int> CountAsync();
    }
}