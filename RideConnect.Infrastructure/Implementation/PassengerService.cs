using Microsoft.AspNetCore.Http;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Infrastructure;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Enums;
using RideConnect.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Infrastructure.Implementation;

public class PassengerService : IPassengerService
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

    public PassengerService(IServiceFactory serviceFactory)
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
        CustomerPersonalData passenger = await _customerPersonalDataRepo.GetSingleByAsync(x => x.Id == userId);
        if (passenger == null)
            throw new InvalidOperationException("Passenger not found.");

        //  Validate ride type
        RideType rideType = await _rideTypeRepo.GetSingleByAsync(x => x.Id == request.RideTypeId);
        if (rideType == null)
            throw new InvalidOperationException("Invalid ride type selected.");

        //  Validate driver
        var driver = await _driverPersonalDataRepo.GetSingleByAsync(x => x.Id == request.DriverId);
        if (driver == null)
            throw new InvalidOperationException("Invalid driver selected.");

        //  Create new ride
        var ride = new Ride
        {
            From = request.From,
            Location = request.Location,
            RideTypeId = request.RideTypeId,
            DriverId = request.DriverId,
            RideStatus = RideStatus.InProgress
        };

        _rideRepo.Add(ride);
        await _unitOfWork.SaveChangesAsync();

        return $"{ride.Id}";


    }

}
