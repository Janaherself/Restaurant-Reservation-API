using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;

namespace RestaurantReservation.API.Presentation.Controllers
{
    /// <summary>
    /// handles all operations related to customers.
    /// </summary>
    /// <param name="_customerService"></param>
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    [Produces("application/json")]
    public class CustomerController(ICustomerService _customerService) : Controller
    {
        /// <summary>
        /// gets a list of all customers
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of customers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var customers = await _customerService.GetAllCustomersAsync(pageNumber, pageSize);
            return Ok(customers);
        }

        /// <summary>
        /// gets a customer by id
        /// </summary>
        /// <param name="id">the id of the customer</param>
        /// <returns>the customer found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} does not exist.");
            }

            return Ok(customer);
        }

        /// <summary>
        /// creates a new customer
        /// </summary>
        /// <param name="customerCreateDto">the new customer details</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            await _customerService.CreateCustomerAsync(customerCreateDto);
            return Created();
        }

        /// <summary>
        /// updaes a customer
        /// </summary>
        /// <param name="id">the id of the customer to update</param>
        /// <param name="customerUpdateDto">the new customer details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
        {
            var isUpdated = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Customer with ID {id} does not exist.");
            }

            return Ok($"Customer with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes a customer
        /// </summary>
        /// <param name="id">the id of the customer to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var isDeleted = await _customerService.DeleteCustomerAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Customer with ID {id} does not exist.");
            }

            return Ok($"Customer with ID {id} has been deleted.");
        }
    }
}
