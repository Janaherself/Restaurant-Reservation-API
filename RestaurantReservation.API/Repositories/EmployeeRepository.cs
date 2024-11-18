using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class EmployeeRepository(RestaurantReservationDbContext context) : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Employee>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> ListManagersAsync()
        {
            return await _context.Employees
                .Where(e => e.Position == "Manager")
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Employees.CountAsync();
        }
    }
}
