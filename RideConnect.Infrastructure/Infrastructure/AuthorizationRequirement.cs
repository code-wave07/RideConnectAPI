using Microsoft.AspNetCore.Authorization;

namespace RideConnect.Services.Infrastructure
{
    public class AuthorizationRequirment : IAuthorizationRequirement
    {
        public int Success { get; set; }
    }
}