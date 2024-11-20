﻿using AutoMapper;
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
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return false;
            }

            _mapper.Map(employeeUpdateDto, employee);
            await _employeeRepository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
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