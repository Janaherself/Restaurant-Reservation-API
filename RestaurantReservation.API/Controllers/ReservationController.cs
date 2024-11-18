using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController(IReservationService reservationService) : Controller
    {
        private readonly IReservationService _reservationService = reservationService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var reservations = await _reservationService.GetAllReservationsAsync(pageNumber, pageSize);
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound("Invalid Reservation Id!");
            }

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(Reservation reservation)
        {
            await _reservationService.CreateReservationAsync(reservation);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return BadRequest("Invalid Reservation Id!");
            }

            await _reservationService.UpdateReservationAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var isDeleted = await _reservationService.DeleteReservationAsync(id);
            if (!isDeleted)
            {
                return BadRequest($"Reservation with ID {id} does not exist.");
            }

            return Ok($"Reservation with ID {id} has been deleted.");
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsOfCustomer(int customerId)
        {
            var reservations = await _reservationService.GetReservationsByCustomerAsync(customerId);
            if (reservations == null)
            {
                return BadRequest("Invalid Customer Id!");
            }

            return Ok(reservations);
        }
    }
}
