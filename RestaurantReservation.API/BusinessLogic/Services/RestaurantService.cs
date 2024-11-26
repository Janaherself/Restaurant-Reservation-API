using AutoMapper;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.Services
{
    public class RestaurantService(IRestaurantRepository _restaurantRepository, IMapper _mapper) : IRestaurantService
    {
        public async Task<PaginatedResult<RestaurantReadDto>> GetAllRestaurantsAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _restaurantRepository.CountAsync();
            var restaurants = await _restaurantRepository.GetAllAsync(pageNumber, pageSize);

            var restaurantDtos = _mapper.Map<IEnumerable<RestaurantReadDto>>(restaurants);

            return new PaginatedResult<RestaurantReadDto>
            {
                Items = restaurantDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<RestaurantReadDto> GetRestaurantByIdAsync(int id)
        {
            return _mapper.Map<RestaurantReadDto>(await _restaurantRepository.GetByIdAsync(id));
        }

        public async Task CreateRestaurantAsync(RestaurantCreateDto restaurantCreateDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantCreateDto);
            await _restaurantRepository.CreateAsync(restaurant);
        }

        public async Task<bool> UpdateRestaurantAsync(int id, RestaurantUpdateDto restaurantUpdateDto)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return false;
            }

            _mapper.Map(restaurantUpdateDto, restaurant);
            await _restaurantRepository.UpdateAsync(restaurant);
            return true;
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
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