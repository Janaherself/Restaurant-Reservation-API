using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<CustomerReadDto>> GetAllCustomersAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _customerRepository.CountAsync();
            var customers = await _customerRepository.GetAllAsync(pageNumber, pageSize);

            var customerDtos = _mapper.Map<List<CustomerReadDto>>(customers);

            return new PaginatedResult<CustomerReadDto>
            {
                Items = customerDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / pageSize)
            };
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return false;
            }
            
            await _customerRepository.DeleteAsync(customer);
            return true;
        }
    }
}
