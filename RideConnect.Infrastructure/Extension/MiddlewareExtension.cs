using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RideConnect.Data.Context;
using RideConnect.Data.Implementation;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Implementation;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;

namespace RideConnect.Infrastructure.Extension;

public static class MiddlewareExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IDriverService, DriverService>();
        services.AddTransient<IServiceFactory, ServiceFactory>();
        services.AddTransient<IUnitOfWork, UnitOfWork<RideConnectDbContext>>();
    }
}
