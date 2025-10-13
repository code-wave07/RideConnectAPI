using Microsoft.EntityFrameworkCore;
using RideConnect.Data.Context;
using RideConnect.Infrastructure.Extension;
using RideConnect.Data.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddDbContext<RideConnectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly("RideConnect.Data");
    }));

builder.Services.AddIdentity();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
