using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tables")]
    public class TableController(ITableService tableService) : Controller
    {
        private readonly ITableService _tableService = tableService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var tables = await _tableService.GetAllTablesAsync(pageNumber, pageSize);
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound("Invalid Table Id!");
            }

            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTable(Table table)
        {
            await _tableService.CreateTableAsync(table);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, Table table)
        {
            if (id != table.TableId)
            {
                return BadRequest("Invalid Table Id!");
            }

            await _tableService.UpdateTableAsync(table);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var isDeleted = await _tableService.DeleteTableAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Table with ID {id} does not exist.");
            }

            return Ok($"Table with ID {id} has been deleted.");
        }
    }
}
