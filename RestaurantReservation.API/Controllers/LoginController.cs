﻿using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Authorization;

namespace RestaurantReservation.API.Controllers
{
    /// <summary>
    /// handles user login
    /// </summary>
    /// <param name="tokenGenerator"></param>
    [ApiController]
    [Route("api/login")]
    public class LoginController(JwtTokenGenerator tokenGenerator) : Controller
    {
        private readonly JwtTokenGenerator _tokenGenerator = tokenGenerator;

        /// <summary>
        /// authenticates a user
        /// </summary>
        /// <param name="request">the username and password of a user</param>
        /// <returns>200 OK with a token if authenticated, or 401 Unauthorized</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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