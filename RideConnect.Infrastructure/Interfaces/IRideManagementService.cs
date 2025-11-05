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
    public Task<List<RideDetailsResponse>> GetAllRides();
    public Task<RideDetailsResponse> GetRideDetails(string rideId);
//<<<<<<< HEAD

    public Task<RideDetailsResponse> GetRidesbyPassenger();
//=======
    public Task<string> CancelOrRejectRideAsync(string rideId);
//>>>>>>> 1932df1cda457423c8e98902768639390e8d957d
}
