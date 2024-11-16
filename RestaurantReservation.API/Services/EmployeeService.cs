using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class EmployeeService(IEmployeeRepository EmployeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = EmployeeRepository;

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            // data validation goes here
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            // validation
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            // validation
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetMnagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }
    }
}