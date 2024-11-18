using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IReservationService
    {
        Task CreateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(int id);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task UpdateReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>>? GetReservationsByCustomerAsync(int customerId);
        Task<IEnumerable<ReservationView>> ListReservationViewAsync();
    }
}