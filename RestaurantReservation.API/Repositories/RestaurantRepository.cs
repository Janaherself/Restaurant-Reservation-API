using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.RepositoriesInterfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class RestaurantRepository(RestaurantReservationDbContext context) : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Restaurant>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Restaurants
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

        }

        public async Task<int> CountAsync()
        {
            return await _context.Restaurants.CountAsync();
        }
    }
}
