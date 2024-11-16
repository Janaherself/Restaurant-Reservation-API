using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IReservationRepository
    {
        Task CreateAsync(Reservation reservation);
        Task DeleteAsync(int id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task UpdateAsync(Reservation reservation);
    }
}