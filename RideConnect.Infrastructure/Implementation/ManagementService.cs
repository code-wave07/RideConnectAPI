
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
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
    public async Task<string> CreateRideType(string rideType)
    {
        RideType rideT = await _rideTypeRepo.GetSingleBy();

        if (rideT == null)
            throw new InvalidOperationException("Ride type already exists.");

        return "Successfully created.";
    }
}
