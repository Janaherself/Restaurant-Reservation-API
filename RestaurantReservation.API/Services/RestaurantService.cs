using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class RestaurantService(IRestaurantRepository RestaurantRepository, IMapper mapper) : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = RestaurantRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<RestaurantReadDto>> GetAllRestaurantsAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _restaurantRepository.CountAsync();
            var restaurants = await _restaurantRepository.GetAllAsync(pageNumber, pageSize);

            var restaurantDtos = _mapper.Map<List<RestaurantReadDto>>(restaurants);

            return new PaginatedResult<RestaurantReadDto>
            {
                Items = restaurantDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / pageSize)
            };
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