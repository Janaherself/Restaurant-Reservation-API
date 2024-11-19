using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateRestaurantAsync(RestaurantCreateDto restaurantCreateDto);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<PaginatedResult<RestaurantReadDto>> GetAllRestaurantsAsync(int pageNumber, int pageSize);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<bool> UpdateRestaurantAsync(int id, RestaurantUpdateDto restaurantUpdateDto);
    }
}