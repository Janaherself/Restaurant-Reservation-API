using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<PaginatedResult<RestaurantReadDto>> GetAllRestaurantsAsync(int pageNumber, int pageSize);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task UpdateRestaurantAsync(Restaurant restaurant);
    }
}