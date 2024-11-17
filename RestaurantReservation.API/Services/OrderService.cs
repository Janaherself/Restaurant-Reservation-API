using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class OrderService(IOrderRepository OrderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = OrderRepository;

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            // data validation goes here
            await _orderRepository.CreateAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            // validation
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            // validation
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _orderRepository.CalculateAverageOrderAmountAsync(employeeId);
        }

        public async Task<IEnumerable<Order>>? ListOrdersAndMenuItemsAsync(int reservationId)
        {
            var orders = await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
            if (!orders.Any())
            {
                return null;
            }
            return orders;
        }
    }
}