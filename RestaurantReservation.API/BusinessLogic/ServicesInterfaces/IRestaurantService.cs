using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
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