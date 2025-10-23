using Azure;
using RideConnect.Models.Entities;

namespace RideConnect.Infrastructure.Interfaces;

public interface IManagementService
{
   public Task<string> CreateRideType(string rideType);
}
