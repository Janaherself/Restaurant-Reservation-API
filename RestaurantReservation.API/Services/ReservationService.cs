using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class ReservationService(IReservationRepository ReservationRepository) : IReservationService
    {
        private readonly IReservationRepository _reservationRepository = ReservationRepository;

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            // data validation goes here
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            // validation
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            // validation
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            await _reservationRepository.DeleteAsync(reservation);
            return true;
        }

        public async Task<IEnumerable<Reservation>>? GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await _reservationRepository.GetReservationsByCustomerAsync(customerId);
            if (!reservations.Any())
            {
                return null;
            }
            return reservations;
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _reservationRepository.ListReservationViewAsync();
        }
    }
}