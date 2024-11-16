using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task UpdateAsync(Employee employee);
        Task<IEnumerable<Employee>> ListManagersAsync();
    }
}