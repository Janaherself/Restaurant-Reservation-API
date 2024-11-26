using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<PaginatedResult<EmployeeReadDto>> GetAllEmployeesAsync(int pageNumber, int pageSize);
        Task<EmployeeReadDto> GetEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task<IEnumerable<EmployeeReadDto>> GetMnagersAsync();
    }
}