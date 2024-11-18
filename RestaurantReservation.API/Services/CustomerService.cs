using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            // data validation goes here
            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            // validation
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            // validation
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
