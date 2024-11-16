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

        public async Task DeleteReservationAsync(int id)
        {
            // validation
            await _reservationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _reservationRepository.ListReservationViewAsync();
        }
    }
}