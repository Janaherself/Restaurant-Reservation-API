using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController(ICustomerService customerService) : Controller
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { Message = "Invalid Customer Id!" });
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            await _customerService.CreateCustomerAsync(customer);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest(new { Message = "Invalid Customer Id!" });
            }

            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
