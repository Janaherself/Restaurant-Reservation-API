using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IRestaurantRepository
    {
        Task CreateAsync(Restaurant restaurant);
        Task DeleteAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllAsync(int pageNumber, int pageSize);
        Task<Restaurant> GetByIdAsync(int id);
        Task UpdateAsync(Restaurant restaurant);
        Task<int> CountAsync();
    }
}