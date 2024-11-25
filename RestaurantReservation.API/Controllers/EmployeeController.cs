using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.ServicesInterfaces;

namespace RestaurantReservation.API.Controllers
{
    /// <summary>
    /// handles all operations related to employees.
    /// </summary>
    /// <param name="employeeService"></param>
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    [Produces("application/json")]
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;

        /// <summary>
        /// gets a list of all employees
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>paginated list of employees</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var employees = await _employeeService.GetAllEmployeesAsync(pageNumber, pageSize);
            return Ok(employees);
        }

        /// <summary>
        /// gets an employee by id
        /// </summary>
        /// <param name="id">the id of the employee</param>
        /// <returns>the employee found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} does not exist.");
            }

            return Ok(employee);
        }

        /// <summary>
        /// creates a new employee
        /// </summary>
        /// <param name="employeeCreateDto">the new employee details</param>
        /// <returns>200 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            await _employeeService.CreateEmployeeAsync(employeeCreateDto);
            return Created();
        }

        /// <summary>
        /// updates an employee
        /// </summary>
        /// <param name="id">the id of the employee to update</param>
        /// <param name="employeeUpdateDto">the new employee details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateEmployee(int id,  EmployeeUpdateDto employeeUpdateDto)
        {
            var isUpdated = await _employeeService.UpdateEmployeeAsync(id, employeeUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Employee with ID {id} does not exist.");
            }

            return Ok($"Employee with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes an employee
        /// </summary>
        /// <param name="id">the id of the employee to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Employee with ID {id} does not exist.");
            }

            return Ok($"Employee with ID {id} has been deleted.");
        }

        /// <summary>
        /// returns a list of managers
        /// </summary>
        /// <returns>a list of managers</returns>
        [HttpGet("managers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetMangers()
        {
            var managers = await _employeeService.GetMnagersAsync();
            return Ok(managers);
        }
    }
}
 