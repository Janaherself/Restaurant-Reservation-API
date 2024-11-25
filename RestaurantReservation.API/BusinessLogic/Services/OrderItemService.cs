using AutoMapper;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.Services
{
    public class OrderItemService(IOrderItemRepository OrderItemRepository, IMapper mapper) : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository = OrderItemRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<OrderItemReadDto>> GetAllOrderItemsAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _orderItemRepository.CountAsync();
            var orderItems = await _orderItemRepository.GetAllAsync(pageNumber, pageSize);

            var orderItemDtos = _mapper.Map<List<OrderItemReadDto>>(orderItems);

            return new PaginatedResult<OrderItemReadDto>
            {
                Items = orderItemDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task CreateOrderItemAsync(OrderItemCreateDto orderItemCreateDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemCreateDto);
            await _orderItemRepository.CreateAsync(orderItem);
        }

        public async Task<bool> UpdateOrderItemAsync(int id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
                return false;
            }

            _mapper.Map(orderItemUpdateDto, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
            return true;
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
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