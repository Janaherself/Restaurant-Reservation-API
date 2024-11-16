using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { Message = "Invalid Employee Id!" });
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
                return BadRequest(new {message = "Invalid EmployeeId!"});
            }
            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetMangers()
        {
            var managers = await _employeeService.GetMnagersAsync();
            return Ok(managers);
        }
    }
}
 