using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    public class CustomerController(ICustomerService customerService) : Controller
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var customers = await _customerService.GetAllCustomersAsync(pageNumber, pageSize);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound("Invalid Customer Id!");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            await _customerService.CreateCustomerAsync(customerCreateDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
        {
            var isUpdated = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
            if (!isUpdated)
            {
                return BadRequest($"Customer with ID {id} does not exist.");
            }

            return Ok($"Customer with ID {id} has been updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var isDeleted = await _customerService.DeleteCustomerAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Customer with ID {id} does not exist.");
            }

            return Ok($"Customer with ID {id} has been deleted.");
        }
    }
}
