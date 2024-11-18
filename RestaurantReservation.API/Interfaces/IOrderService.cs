using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task UpdateOrderAsync(Order order);
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
        Task<IEnumerable<Order>>? ListOrdersAndMenuItemsAsync(int reservationId);
    }
}