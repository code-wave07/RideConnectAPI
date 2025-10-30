using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Infrastructure.Interfaces;

public interface IRideManagementService
{
    public Task<string> BookRide(BookRideRequest request);

    public Task<RideDetailsResponse> GetRideDetails(string rideId);
}
