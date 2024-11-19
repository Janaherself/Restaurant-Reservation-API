using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class OrderRepository(RestaurantReservationDbContext context) : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Orders
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

        }

        public async Task<decimal?> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return null;
            }

            var orders = await _context.Orders
                                       .Where(o => o.EmployeeId == employeeId)
                                       .ToListAsync();

            return orders.Count != 0 ? orders.Average(o => o.TotalAmount) : 0;
        }

        public async Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.MenuItem)
                                 .Where(o => o.ReservationId == reservationId)
                                 .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Orders.CountAsync();
        }
    }
}
