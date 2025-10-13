using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RideConnect.Data.Context;
using RideConnect.Models.Entities;

namespace RideConnect.Data.Extension;

public static class ServiceCollectionExtension
{
    public static void AddIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentityCore<ApplicationUser>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = false;
        });

        builder = new IdentityBuilder(typeof(ApplicationUser), typeof(ApplicationRole),
        services);
        builder.AddEntityFrameworkStores<RideConnectDbContext>();
        //.AddDefaultTokenProviders();
    }
}

