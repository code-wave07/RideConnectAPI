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

    public async Task<List<Ride>> GetRidesByPassenger()
    {
        IQueryable<Ride> RidesQueryable = _rideRepo.GetQueryable(
            include: x => x
                .Include(u => u.Driver)
                .Include(u => u.RideType)
                .Include(u => u.Passenger)
        );

        List<Ride> rides = await RidesQueryable.ToListAsync();

        string userId = _contextAccessor.HttpContext.User.GetUserId();
        if (userId == null)
            throw new InvalidOperationException("User not authenticated.");

        CustomerPersonalData passenger = await _customerPersonalDataRepo.GetSingleByAsync(x => x.UserId == userId);
        if (passenger == null)
            throw new InvalidOperationException("Passenger not found.");

    }

    public Task<RideDetailsResponse> GetRidesbyPassenger()
    {
        throw new NotImplementedException();
    }
}
