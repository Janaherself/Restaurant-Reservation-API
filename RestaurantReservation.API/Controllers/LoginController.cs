using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Authorization;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController(JwtTokenGenerator tokenGenerator) : Controller
    {
        private readonly JwtTokenGenerator _tokenGenerator = tokenGenerator;

        [HttpGet]
        public IActionResult Login(User request)
        {
            if (IsValidUser(request.Username, request.Password))
            {
                var token = _tokenGenerator.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        private bool IsValidUser(string username, string password)
        {
            return username == "guest" && password == "guest";
        }
    }
}
