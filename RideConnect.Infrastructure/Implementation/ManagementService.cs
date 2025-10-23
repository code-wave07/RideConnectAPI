
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;

namespace RideConnect.Infrastructure.Implementation;

public class ManagementService : IManagementService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;
    private readonly IRepository<RideType> _rideTypeRepo;

    public ManagementService(IServiceFactory serviceFactory, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
        _rideTypeRepo = _unitOfWork.GetRepository<RideType>();
    }
    public async Task<string> AddOrUpdateRideType(RideTypeRequest request)
    {
        if (request.Id is not null)
        {
            //Update RideType
            RideType existingRideType = await _rideTypeRepo.GetSingleByAsync(x => x.Id == request.Id);

            if (existingRideType == null)
                throw new InvalidOperationException("Ride Type not found");

            if (existingRideType.Type != request.RideType)
            {
                RideType rideTypeWithSameName = await _rideTypeRepo.GetSingleByAsync(x => x.Type == request.RideType);

                if (rideTypeWithSameName != null)
                    throw new InvalidOperationException($"Ride type with name {request.RideType} already exists.");
            }
            else
            {
                return "Successfully Updated RideType";
            }

            existingRideType.Type = request.RideType;

            _rideTypeRepo.Update(existingRideType);
            await _unitOfWork.SaveChangesAsync();

            return "Successfully Updated.";
        }

        // Request.Id is null so create Ride Type
        RideType exitingRideType = await _rideTypeRepo.GetSingleByAsync(x => x.Type == request.RideType);

        if (exitingRideType != null)
            throw new InvalidOperationException("Ride type already exists.");

        RideType newRideType = new RideType
        {
            Type = request.RideType
        };

        _rideTypeRepo.Add(newRideType);
        await _unitOfWork.SaveChangesAsync();

        return "Successfully created.";
    }
}
