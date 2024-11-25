using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task<bool> DeleteOrderAsync(int id);
        Task<PaginatedResult<OrderReadDto>> GetAllOrdersAsync(int pageNumber, int pageSize);
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto);
        Task<decimal?> CalculateAverageOrderAmountAsync(int employeeId);
        Task<IEnumerable<OrderReadDto>> ListOrdersAndMenuItemsAsync(int reservationId);
    }
}