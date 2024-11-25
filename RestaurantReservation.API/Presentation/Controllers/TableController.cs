using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;

namespace RestaurantReservation.API.Presentation.Controllers
{
    /// <summary>
    /// handles all operations related to tables.
    /// </summary>
    /// <param name="_tableService"></param>
    [Authorize]
    [ApiController]
    [Route("api/tables")]
    [Produces("application/json")]
    public class TableController(ITableService _tableService) : Controller
    {
        /// <summary>
        /// gets a list of all tables 
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of tables</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var tables = await _tableService.GetAllTablesAsync(pageNumber, pageSize);
            return Ok(tables);
        }

        /// <summary>
        /// gets a table by id
        /// </summary>
        /// <param name="id">the id of the table</param>
        /// <returns>the table found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound($"Table with ID {id} does not exist.");
            }

            return Ok(table);
        }

        /// <summary>
        /// creates a new table
        /// </summary>
        /// <param name="tableCreateDto">the new table details</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateTable(TableCreateDto tableCreateDto)
        {
            await _tableService.CreateTableAsync(tableCreateDto);
            return Created();
        }

        /// <summary>
        /// updates a table
        /// </summary>
        /// <param name="id">the id of the table to update</param>
        /// <param name="tableUpdateDto">the new table details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateTable(int id, TableUpdateDto tableUpdateDto)
        {
            var isUpdated = await _tableService.UpdateTableAsync(id, tableUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Table with ID {id} does not exist.");
            }

            return Ok($"Table with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes a table
        /// </summary>
        /// <param name="id">the id of the table to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var isDeleted = await _tableService.DeleteTableAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Table with ID {id} does not exist.");
            }

            return Ok($"Table with ID {id} has been deleted.");
        }
    }
}
