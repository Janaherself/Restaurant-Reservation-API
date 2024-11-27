using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IRestaurantService
    {
        Task CreateRestaurantAsync(RestaurantCreateDto restaurantCreateDto);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<PaginatedResult<RestaurantReadDto>> GetAllRestaurantsAsync(int pageNumber, int pageSize);
        Task<RestaurantReadDto> GetRestaurantByIdAsync(int id);
        Task<bool> UpdateRestaurantAsync(int id, RestaurantUpdateDto restaurantUpdateDto);
    }
}