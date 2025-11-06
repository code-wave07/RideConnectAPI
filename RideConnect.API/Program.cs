using Microsoft.EntityFrameworkCore;
using RideConnect.Data.Context;
using RideConnect.Infrastructure.Extension;
using RideConnect.Data.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RideConnect.Services.Infrastructure;
using System.Text;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

IConfiguration configuration = builder.Configuration;
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JWTConfiguration>();
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddDbContext<RideConnectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly("RideConnect.Data");
    }));

builder.Services.AddIdentity();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = true
        };
        jwt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;

                if (!string.IsNullOrEmpty(accessToken) &&
                    path.StartsWithSegments("/api/signalRHub"))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(24);
});

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Authorization", policy => policy.Requirements.Add(new AuthorizationRequirment()));
});

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder => {
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(
        "https://ride-connect-pearl.vercel.app",
        "http://localhost:5500",
        "http://127.0.0.1:5500" )
        
        .AllowCredentials();

}));

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResourceEdge v4");
    c.InjectStylesheet("/css/swagger-dark-theme.css");
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
