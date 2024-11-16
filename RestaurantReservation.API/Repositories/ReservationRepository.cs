using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Repositories
{
    public class ReservationRepository(RestaurantReservationDbContext context) : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context = context;

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
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

        public async Task DeleteAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                           .Include(r => r.Customer)
                           .Include(r => r.Restaurant)
                           .Include(r => r.ReservationDate)
                           .Where(r => r.CustomerId == customerId)
                           .ToListAsync();
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _context.ReservationsView.ToListAsync();
        }
    }
}
