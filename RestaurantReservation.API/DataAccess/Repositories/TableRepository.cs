using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.DataAccess.Repositories
{
    public class TableRepository(RestaurantReservationDbContext context) : ITableRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Table>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Tables
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task CreateAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Tables.CountAsync();
        }
    }
}
