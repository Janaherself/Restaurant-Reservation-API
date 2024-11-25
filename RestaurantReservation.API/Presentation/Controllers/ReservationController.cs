using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;

namespace RestaurantReservation.API.Presentation.Controllers
{
    /// <summary>
    /// handles all operations related to reservations.
    /// </summary>
    /// <param name="reservationService"></param>
    [Authorize]
    [ApiController]
    [Route("api/reservations")]
    [Produces("application/json")]
    public class ReservationController(IReservationService reservationService) : Controller
    {
        private readonly IReservationService _reservationService = reservationService;

        /// <summary>
        /// gets a list of all reservations
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">number of records in a page</param>
        /// <returns>a paginated list of reservations</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var reservations = await _reservationService.GetAllReservationsAsync(pageNumber, pageSize);
            return Ok(reservations);
        }

        /// <summary>
        /// gets a reservation by id
        /// </summary>
        /// <param name="id">the id of the reservation</param>
        /// <returns>the reservation found, or 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound($"Reservation with ID {id} does not exist.");
            }

            return Ok(reservation);
        }

        /// <summary>
        /// creates a new reservation
        /// </summary>
        /// <param name="reservationCreateDto">the new reservation details</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            await _reservationService.CreateReservationAsync(reservationCreateDto);
            return Created();
        }

        /// <summary>
        /// updates a reservation
        /// </summary>
        /// <param name="id">the id of the reservation to update</param>
        /// <param name="reservationUpdateDto">the new reservation details</param>
        /// <returns>200 OK if updated, or 404 Not Found</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            var isUpdated = await _reservationService.UpdateReservationAsync(id, reservationUpdateDto);
            if (!isUpdated)
            {
                return NotFound($"Reservation with ID {id} does not exist.");
            }

            return Ok($"Reservation with ID {id} has been updated.");
        }

        /// <summary>
        /// deletes a reservation
        /// </summary>
        /// <param name="id">the id of the reservation to delete</param>
        /// <returns>200 OK if deleted, or 404 Not Found</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var isDeleted = await _reservationService.DeleteReservationAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Reservation with ID {id} does not exist.");
            }

            return Ok($"Reservation with ID {id} has been deleted.");
        }

        /// <summary>
        /// gets a list of reservations of a customer
        /// </summary>
        /// <param name="customerId">the id of the customer</param>
        /// <returns>a list of reservations of a customer, or 404 Not Found</returns>
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsOfCustomer(int customerId)
        {
            var reservations = await _reservationService.GetReservationsByCustomerAsync(customerId);
            if (reservations == null)
            {
                return NotFound($"Cutomer with ID {customerId} does not exist, or has no reservations.");
            }

            return Ok(reservations);
        }
    }
}
