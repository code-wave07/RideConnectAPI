using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using RideConnect.Data.Context;
using RideConnect.Data.Implementation;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Implementation;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Services.Infrastructure;

namespace RideConnect.Infrastructure.Extension;

public static class MiddlewareExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IDriverService, DriverService>();
        services.AddTransient<IServiceFactory, ServiceFactory>();
        services.AddTransient<IUnitOfWork, UnitOfWork<RideConnectDbContext>>();
        services.AddTransient<IJWTAuthenticator, JWTAuthenticator>();
        services.AddTransient<IPassengerService, PassengerService>();
    }
}
