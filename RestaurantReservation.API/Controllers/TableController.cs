using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.API.Services;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/tables")]
    public class TableController(ITableService tableService) : Controller
    {
        private readonly ITableService _tableService = tableService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound(new { Message = "Invalid Table Id!" });
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
                return BadRequest(new { Message = "Invalid Table Id!" });
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
