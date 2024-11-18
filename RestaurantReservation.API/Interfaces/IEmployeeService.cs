using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<PaginatedResult<EmployeeReadDto>> GetAllEmployeesAsync(int pageNumber, int pageSize);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetMnagersAsync();
    }
}