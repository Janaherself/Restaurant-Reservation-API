using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.RepositoriesInterfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync(int pageNumber, int pageSize);
        Task<Employee> GetByIdAsync(int id);
        Task UpdateAsync(Employee employee);
        Task<IEnumerable<Employee>> ListManagersAsync();
        Task<int> CountAsync();
    }
}