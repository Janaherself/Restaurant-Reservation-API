using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync(int pageNumber, int pageSize);
        Task<Customer> GetByIdAsync(int id);
        Task UpdateAsync(Customer customer);
        Task<int> CountAsync();
    }
}