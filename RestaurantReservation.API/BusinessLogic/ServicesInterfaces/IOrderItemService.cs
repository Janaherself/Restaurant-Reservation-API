using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IOrderItemService
    {
        Task CreateOrderItemAsync(OrderItemCreateDto orderItemCreateDto);
        Task<bool> DeleteOrderItemAsync(int id);
        Task<PaginatedResult<OrderItemReadDto>> GetAllOrderItemsAsync(int pageNumber, int pageSize);
        Task<OrderItemReadDto> GetOrderItemByIdAsync(int id);
        Task<bool> UpdateOrderItemAsync(int id, OrderItemUpdateDto orderItemUpdateDto);
        Task<IEnumerable<MenuItemReadDto>?> ListOrderedMenuItemsAsync(int reservationId);
    }
}