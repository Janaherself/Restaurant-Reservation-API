using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(Customer customer);
    }
}