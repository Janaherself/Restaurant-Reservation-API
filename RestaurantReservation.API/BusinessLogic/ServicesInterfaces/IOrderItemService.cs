using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IOrderItemService
    {
        Task CreateOrderItemAsync(OrderItemCreateDto orderItemCreateDto);
        Task<bool> DeleteOrderItemAsync(int id);
        Task<PaginatedResult<OrderItemReadDto>> GetAllOrderItemsAsync(int pageNumber, int pageSize);
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<bool> UpdateOrderItemAsync(int id, OrderItemUpdateDto orderItemUpdateDto);
        Task<IEnumerable<MenuItem>>? ListOrderedMenuItemsAsync(int reservationId);
    }
}