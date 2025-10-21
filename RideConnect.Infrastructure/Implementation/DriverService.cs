using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RideConnect.Data.Interfaces;
using RideConnect.Data.Context;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Requests;
using RideConnect.Models.Enums;
using Microsoft.VisualBasic;
using RideConnect.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using RideConnect.Infrastructure.Infrastructure;

namespace RideConnect.Infrastructure.Implementation;

public class DriverService : IDriverService
{
    private readonly IRepository<ApplicationUser> _applicationUserRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;
    private readonly IRepository<CarDetails> _carDetails;
    private readonly IRepository<CustomerPersonalData> _customerPersonalDataRepo;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<DriverPersonalData> _driverPersonalDataRepo;


    public DriverService(IServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
        _applicationUserRepo = _unitOfWork.GetRepository<ApplicationUser>();
        _carDetails = _unitOfWork.GetRepository<CarDetails>();
        _customerPersonalDataRepo = _unitOfWork.GetRepository<CustomerPersonalData>();
        _contextAccessor = _serviceFactory.GetService<IHttpContextAccessor>();
        _driverPersonalDataRepo = _unitOfWork.GetRepository<DriverPersonalData>();
    }

    public async Task<DriverProfileResponse> GetDriverDetails()
    {
        string userId = _contextAccessor.HttpContext.User.GetUserId();
        

        if (userId == null)
            throw new InvalidOperationException("User not authenticated");

        ApplicationUser driver = await _applicationUserRepo.GetSingleByAsync(x => x.Id == userId,
                    include: x => x.Include(x => x.DriverPersonalData).ThenInclude(x=> x.CarDetails)); //changed from CarDetails to DriverPersonalData since it no longer reference ApplicationUser

        if (driver == null)
            throw new InvalidOperationException("invalid user id ");

        DriverProfileResponse response = new DriverProfileResponse
        {
            FullName = $"{driver.Firstname} {driver.Lastname}",
            EmailAddress = driver.Email!,
            Username = driver.UserName!,
            MobileNumber = driver.PhoneNumber!,
            UserType = driver.UserType.GetStringValue(),
            UserTypeId = driver.UserType,

           DriverPersonalDataResponse = new DriverPersonalDataResponse
           {
               CarDetails = new DriverCarDetailsResponse
               {
                   DlNumber = driver.DriverPersonalData.CarDetails?.DlNumber!,
                   VehicleMake = driver.DriverPersonalData.CarDetails?.VehicleMake!,
                   CarModel = driver.DriverPersonalData.CarDetails?.CarModel!,
                   ProductionYear = driver.DriverPersonalData.CarDetails?.ProductionYear!,
                   CarColor = driver.DriverPersonalData.CarDetails?.CarColor!,
                   CarPlateNumber = driver.DriverPersonalData.CarDetails?.CarPlateNumber!
               }
           }
        };

        return response;
    }

}
