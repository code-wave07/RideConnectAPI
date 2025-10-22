using RideConnect.Models.Response;
using RideConnect.Models.Entities;
using System.Security.Claims;
using RideConnect.Models.Requests;

namespace RideConnect.Services.Infrastructure
{
    public interface IJWTAuthenticator
    {
        Task<JWTToken> GenerateJwtToken(ApplicationUser user, string? expires = null, List<Claim>? additionalClaims = null);
        Task<string> GenerateRefreshToken(ApplicationUser user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}