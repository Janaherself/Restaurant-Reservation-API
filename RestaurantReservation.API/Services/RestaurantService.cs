using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class RestaurantService(IRestaurantRepository RestaurantRepository) : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = RestaurantRepository;

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _restaurantRepository.GetByIdAsync(id);
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            // data validation goes here
            await _restaurantRepository.CreateAsync(restaurant);
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            // validation
            await _restaurantRepository.UpdateAsync(restaurant);
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            // validation
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return false;
            }

            await _restaurantRepository.DeleteAsync(restaurant);
            return true;
        }
    }
}