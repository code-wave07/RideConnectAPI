using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Infrastructure;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Enums;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Infrastructure.Implementation;

public class RideManagementService : IRideManagementService
{

    private readonly IRepository<ApplicationUser> _applicationUserRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;
    private readonly IRepository<CarDetails> _carDetails;
    private readonly IRepository<CustomerPersonalData> _customerPersonalDataRepo;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<DriverPersonalData> _driverPersonalDataRepo;
    private readonly IRepository<Ride> _rideRepo;
    private readonly IRepository<RideType> _rideTypeRepo;

    public RideManagementService(IServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
        _applicationUserRepo = _unitOfWork.GetRepository<ApplicationUser>();
        _carDetails = _unitOfWork.GetRepository<CarDetails>();
        _customerPersonalDataRepo = _unitOfWork.GetRepository<CustomerPersonalData>();
        _contextAccessor = _serviceFactory.GetService<IHttpContextAccessor>();
        _driverPersonalDataRepo = _unitOfWork.GetRepository<DriverPersonalData>();
        _rideRepo = _unitOfWork.GetRepository<Ride>();
        _rideTypeRepo = _unitOfWork.GetRepository<RideType>();
    }

    public async Task<string> BookRide(BookRideRequest request)
    {
        //  Get logged-in passenger
        string userId = _contextAccessor.HttpContext.User.GetUserId();
        if (userId == null)
            throw new InvalidOperationException("User not authenticated.");

        //  Verify passenger exists
        CustomerPersonalData passenger = await _customerPersonalDataRepo.GetSingleByAsync(x => x.UserId == userId);
        if (passenger == null)
            throw new InvalidOperationException("Passenger not found.");

        //  Validate ride type
        RideType rideType = await _rideTypeRepo.GetSingleByAsync(x => x.Id == request.RideTypeId);
        if (rideType == null)
            throw new InvalidOperationException("Invalid ride type selected.");

        //  Validate driver
        DriverPersonalData driver = await _driverPersonalDataRepo.GetSingleByAsync(x => x.Id == request.DriverId);

        if (driver == null)
            throw new InvalidOperationException("Invalid driver selected.");

        //  Create new ride
        var ride = new Ride
        {
            From = request.From,
            Location = request.Location,
            RideTypeId = request.RideTypeId,
            DriverId = request.DriverId,
            PassengerId = passenger.Id,
            RideStatus = RideStatus.InProgress,
            Price = request.Price
        };

        _rideRepo.Add(ride);
        await _unitOfWork.SaveChangesAsync();

        return $"{ride.Id}";


    }



    public async Task<RideDetailsResponse> GetRideDetails(string rideId)
    {
        if (string.IsNullOrEmpty(rideId))
            throw new ArgumentException("Ride ID cannot be null or empty");

        // Get the ride including driver and passenger data
        Ride ride = await _rideRepo.GetSingleByAsync(
            x => x.Id == rideId,
            include: x => x
                .Include(r => r.Driver).ThenInclude(x => x.User)
                .Include(r => r.Passenger).ThenInclude(x => x.User)
                .Include(r => r.RideType)
        );

        if (ride == null)
            throw new InvalidOperationException("Ride not found");


        RideDetailsResponse response = new RideDetailsResponse
        {
            RideId = ride.Id,
            From = ride.From,
            Location = ride.Location,
            Price = ride.Price,
            RideStatus = ride.RideStatus.ToString(),
            RideStatusId = ride.RideStatus,
            RideType = new RideTypeResponse
            {
                Name = ride.RideType.Type,
                RideTypeId = ride.RideTypeId,
            },
            Driver = new DriverDataResponse
            {
                Fullname = $"{ride.Driver.User.Firstname} {ride.Driver.User.Lastname}",
                DriverId = ride.DriverId,
            },
            Customer = new CustomerDataResponse
            {
                Fullname = $"{ride.Passenger.User.Firstname} {ride.Passenger.User.Lastname}",
                CustomerId = ride.PassengerId
            }
        };

        return response;
    }

//<<<<<<< HEAD
    //public async Task<List<Ride>> GetRidesByPassenger()
    //{
    //    IQueryable<Ride> RidesQueryable = _rideRepo.GetQueryable(
    //        include: x => x
    //            .Include(u => u.Driver)
    //            .Include(u => u.RideType)
    //            .Include(u => u.Passenger)
    //    );

    //    List<Ride> rides = await RidesQueryable.ToListAsync();

    //    string userId = _contextAccessor.HttpContext.User.GetUserId();
    //    if (userId == null)
    //        throw new InvalidOperationException("User not authenticated.");

    //    CustomerPersonalData passenger = await _customerPersonalDataRepo.GetSingleByAsync(x => x.UserId == userId);
    //    if (passenger == null)
    //        throw new InvalidOperationException("Passenger not found.");

    //}

    public Task<RideDetailsResponse> GetRidesbyPassenger()
    {
        throw new NotImplementedException();
    }
//=======
    public async Task<List<RideDetailsResponse>> GetAllRides()
    {
     
        IQueryable<Ride> ridesQueryable = _rideRepo.GetQueryable(
            include: x => x
                .Include(r => r.Driver).ThenInclude(d => d.User)
                .Include(r => r.Passenger).ThenInclude(p => p.User)
                .Include(r => r.RideType)
        );

       
        List<Ride> rides = await ridesQueryable.ToListAsync();

     
        if (!rides.Any())
            return new List<RideDetailsResponse>();

    
        List<RideDetailsResponse> responses = rides.Select(ride => new RideDetailsResponse
        {
            RideId = ride.Id,
            From = ride.From,
            Location = ride.Location,
            Price = ride.Price,
            RideStatus = ride.RideStatus.ToString(),
            RideStatusId = ride.RideStatus,
            RideType = new RideTypeResponse
            {
                Name = ride.RideType?.Type ?? string.Empty,
                RideTypeId = ride.RideTypeId,
            },
            Driver = new DriverDataResponse
            {
                Fullname = $"{ride.Driver?.User?.Firstname ?? ""} {ride.Driver?.User?.Lastname ?? ""}".Trim(),
                DriverId = ride.DriverId
            },
            Customer = new CustomerDataResponse
            {
                Fullname = $"{ride.Passenger?.User?.Firstname ?? ""} {ride.Passenger?.User?.Lastname ?? ""}".Trim(),
                CustomerId = ride.PassengerId
            }
        }).ToList();

      
        return responses;
    }

    //public async Task<string> CancelOrRejectRideAsync(string rideId)
    //{
    //    if (string.IsNullOrEmpty(rideId))
    //        throw new ArgumentException("Ride ID cannot be null or empty.");

    //    // Get logged-in user ID
    //    string userId = _contextAccessor.HttpContext.User.GetUserId();
    //    if (userId == null)
    //        throw new InvalidOperationException("User not authenticated.");

    //    // Get the user's role/type
    //    ApplicationUser user = await _applicationUserRepo.GetSingleByAsync(x => x.Id == userId);
    //    if (user == null)
    //        throw new InvalidOperationException("User not found.");

    //    // Fetch the ride
    //    Ride ride = await _rideRepo.GetSingleByAsync(
    //        x => x.Id == rideId,
    //        include: x => x.Include(r => r.Driver).Include(r => r.Passenger)
    //    );

    //    if (ride == null)
    //        throw new InvalidOperationException("Ride not found.");

    //    // Prevent invalid operations
    //    if (ride.RideStatus == RideStatus.Completed)
    //        throw new InvalidOperationException("Completed rides cannot be cancelled or rejected.");

    //    if (ride.RideStatus == RideStatus.Cancelled)
    //        throw new InvalidOperationException("Ride is already cancelled or rejected.");

    //    // Handle based on user type
    //    if (user.UserType == UserType.Customer)
    //    {
    //        // Passenger cancellation
    //        if (ride.PassengerId != userId)
    //            throw new InvalidOperationException("You can only cancel your own rides.");

    //        ride.RideStatus = RideStatus.Cancelled;
    //        _rideRepo.Update(ride);

    //        await _unitOfWork.SaveChangesAsync();
    //        return $"Ride {ride.Id} cancelled by passenger.";
    //    }
    //    else if (user.UserType == UserType.Driver)
    //    {
    //        // Driver rejection
    //        if (ride.DriverId != userId)
    //            throw new InvalidOperationException("You can only reject rides assigned to you.");

    //        ride.RideStatus = RideStatus.Rejected;
    //        _rideRepo.Update(ride);

    //        await _unitOfWork.SaveChangesAsync();
    //        return $"Ride {ride.Id} rejected by driver.";
    //    }
    //    else
    //    {
    //        throw new InvalidOperationException("User type not allowed to perform this action.");
    //    }
    //}

    public async Task<string> CancelRide(string rideId)
    {
        string UserId = _contextAccessor.HttpContext.User.GetUserId();

        if (string.IsNullOrEmpty(rideId))
            throw new ArgumentException("Ride ID is required.");

        Ride ride = await _rideRepo.GetSingleByAsync(x => x.Id == rideId);
        if (ride == null)
            throw new InvalidOperationException("Ride not found.");

        // Check that current user is the passenger
        if (ride.Passenger?.UserId != UserId)
            throw new UnauthorizedAccessException("You are not authorized to cancel this ride.");

        if (ride.RideStatus == RideStatus.Completed || ride.RideStatus == RideStatus.Cancelled)
            throw new InvalidOperationException("Cannot cancel this ride. It has already been completed or cancelled.");

        ride.RideStatus = RideStatus.Cancelled;
        ride.UpdatedAt = DateTime.Now;

        _rideRepo.Update(ride);
        await _unitOfWork.SaveChangesAsync();

        return $"Ride {ride.Id} has been cancelled successfully.";
    }

    public async Task<string> RejectRide(string rideId)
    {
        string userId = _contextAccessor.HttpContext.User.GetUserId();

        if (string.IsNullOrEmpty(rideId))
            throw new ArgumentException("Ride ID is required.");

        Ride ride = await _rideRepo.GetSingleByAsync(x => x.Id == rideId);
        if (ride == null)
            throw new InvalidOperationException("Ride not found.");

        // Verify that current user is the driver for this ride
        if (ride.Driver?.UserId != userId)
            throw new UnauthorizedAccessException("You are not authorized to reject this ride.");

        // Validate ride status
        if (ride.RideStatus != RideStatus.Pending)
            throw new InvalidOperationException("Ride cannot be rejected at this stage.");

        // Update status
        ride.RideStatus = RideStatus.Rejected;
        ride.UpdatedAt = DateTime.Now;

        _rideRepo.Update(ride);
        await _unitOfWork.SaveChangesAsync();

        return $"Ride {ride.Id} has been rejected successfully.";
    }


    public async Task<List<RTResponse>> GetRideTypes()
    {
        IEnumerable<RideType> rideTypesEnumerable = await _rideTypeRepo.GetAllAsync();
        List<RideType> rideTypes = rideTypesEnumerable.ToList();

        if (!rideTypes.Any())
            throw new InvalidOperationException("No ride types found.");

        List<RTResponse> response = rideTypes.Select(rideType => new RTResponse
        {
            RideTypeId = rideType.Id,
            Name = rideType.Type,
            Description = rideType.Description ?? string.Empty
        }).ToList();

        return response;
    }

}
