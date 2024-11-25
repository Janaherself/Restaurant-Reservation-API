using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.DataAccess.Repositories
{
    public class ReservationRepository(RestaurantReservationDbContext _context) : IReservationRepository
    {
        public async Task<IEnumerable<Reservation>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Reservations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);

        }

        public async Task CreateAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                           .Include(r => r.Customer)
                           .Include(r => r.Restaurant)
                           .Where(r => r.CustomerId == customerId)
                           .ToListAsync();
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _context.ReservationsView.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Reservations.CountAsync();
        }
    }
}
