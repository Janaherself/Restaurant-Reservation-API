using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<PaginatedResult<CustomerReadDto>> GetAllCustomersAsync(int pageNumber, int pageSize);
        Task<CustomerReadDto> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto);
    }
}