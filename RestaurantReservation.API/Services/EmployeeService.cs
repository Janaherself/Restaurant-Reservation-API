using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class EmployeeService(IEmployeeRepository EmployeeRepository, IMapper mapper) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = EmployeeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<EmployeeReadDto>> GetAllEmployeesAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _employeeRepository.CountAsync();
            var employees = await _employeeRepository.GetAllAsync(pageNumber, pageSize);

            var employeeDtos = _mapper.Map<List<EmployeeReadDto>>(employees);

            return new PaginatedResult<EmployeeReadDto>
            {
                Items = employeeDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / pageSize)
            };
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

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            // validation
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return false;
            }

            await _employeeRepository.DeleteAsync(employee);
            return true;
        }

        public async Task<IEnumerable<Employee>> GetMnagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }
    }
}