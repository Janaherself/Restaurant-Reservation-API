using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.DataAccess.Repositories
{
    public class CustomerRepository(RestaurantReservationDbContext context) : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Customer>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Customers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Customers.CountAsync();
        }
    }
}
