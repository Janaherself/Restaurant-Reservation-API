using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetMnagersAsync();
    }
}