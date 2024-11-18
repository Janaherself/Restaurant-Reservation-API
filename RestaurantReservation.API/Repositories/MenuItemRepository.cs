using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class MenuItemRepository(RestaurantReservationDbContext context) : IMenuItemRepository
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

        public async Task DeleteAsync(MenuItem menuItem)
        {
            _context.MenuItem.Remove(menuItem);
            await _context.SaveChangesAsync();

        }
    }
}
