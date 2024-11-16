using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/reservation")]
    public class ReservationController(RestaurantReservationDbContext context) : Controller
    {
        private readonly RestaurantReservationDbContext _context = context;
    }
}
