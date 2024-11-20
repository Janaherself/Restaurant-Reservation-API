using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<PaginatedResult<CustomerReadDto>> GetAllCustomersAsync(int pageNumber, int pageSize);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto);
    }
}