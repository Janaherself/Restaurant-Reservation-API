using AutoMapper;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.Services
{
    public class OrderService(IOrderRepository _orderRepository, IMapper _mapper) : IOrderService
    {
        public async Task<PaginatedResult<OrderReadDto>> GetAllOrdersAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _orderRepository.CountAsync();
            var orders = await _orderRepository.GetAllAsync(pageNumber, pageSize);

            var orderDtos = _mapper.Map<List<OrderReadDto>>(orders);

            return new PaginatedResult<OrderReadDto>
            {
                Items = orderDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            await _orderRepository.CreateAsync(order);
        }

        public async Task<bool> UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return false;
            }

            _mapper.Map(orderUpdateDto, order);
            await _orderRepository.UpdateAsync(order);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return false;
            }

            await _orderRepository.DeleteAsync(order);
            return true;
        }

        public async Task<decimal?> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _orderRepository.CalculateAverageOrderAmountAsync(employeeId);
        }

        public async Task<IEnumerable<OrderReadDto>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            var orders = await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
            if (!orders.Any())
            {
                return null;
            }

            var ordersList = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return ordersList;
        }
    }
}