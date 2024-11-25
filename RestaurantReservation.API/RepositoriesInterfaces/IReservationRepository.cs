using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.RepositoriesInterfaces
{
    public interface IReservationRepository
    {
        Task CreateAsync(Reservation reservation);
        Task DeleteAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllAsync(int pageNumber, int pageSize);
        Task<Reservation> GetByIdAsync(int id);
        Task UpdateAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<IEnumerable<ReservationView>> ListReservationViewAsync();
        Task<int> CountAsync();
    }
}