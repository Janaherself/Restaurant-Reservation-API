using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<PaginatedResult<EmployeeReadDto>> GetAllEmployeesAsync(int pageNumber, int pageSize);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task<IEnumerable<Employee>> GetMnagersAsync();
    }
}