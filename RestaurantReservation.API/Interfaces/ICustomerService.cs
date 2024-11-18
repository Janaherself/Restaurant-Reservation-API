using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<PaginatedResult<CustomerReadDto>> GetAllCustomersAsync(int pageNumber, int pageSize);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(Customer customer);
    }
}