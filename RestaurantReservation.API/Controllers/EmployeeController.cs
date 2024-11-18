using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var employees = await _employeeService.GetAllEmployeesAsync(pageNumber, pageSize);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Invalid Employee Id!");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,  Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("Invalid Employee Id!");
            }

            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Employee with ID {id} does not exist.");
            }

            return Ok($"Employee with ID {id} has been deleted.");
        }

        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetMangers()
        {
            var managers = await _employeeService.GetMnagersAsync();
            return Ok(managers);
        }
    }
}
 