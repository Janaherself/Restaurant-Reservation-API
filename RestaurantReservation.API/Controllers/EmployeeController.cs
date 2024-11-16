using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController(RestaurantReservationDbContext context) : Controller
    {
        private readonly RestaurantReservationDbContext _context = context;
    }
}
