using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class MenuItemRepository(RestaurantReservationDbContext context)
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItem.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItem.FindAsync(id);
        }

        public async Task CreateAsync(MenuItem menuItem)
        {
            _context.MenuItem.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItem.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await GetByIdAsync(id);
            if (menuItem != null)
            {
                _context.MenuItem.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
