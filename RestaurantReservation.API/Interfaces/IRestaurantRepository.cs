using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IRestaurantRepository
    {
        Task CreateAsync(Restaurant restaurant);
        Task DeleteAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(int id);
        Task UpdateAsync(Restaurant restaurant);
    }
}