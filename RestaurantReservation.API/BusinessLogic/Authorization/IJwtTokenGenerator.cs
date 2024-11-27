using System.Security.Claims;

namespace RestaurantReservation.API.BusinessLogic.Authorization
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
