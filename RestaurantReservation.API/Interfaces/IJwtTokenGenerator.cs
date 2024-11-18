using System.Security.Claims;

namespace RestaurantReservation.API.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
