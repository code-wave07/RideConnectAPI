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

namespace RideConnect.Infrastructure.Implementation;

public class DriverService : IDriverService
{
    private readonly IRepository<ApplicationUser> _applicationUserRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;
    private readonly IRepository<DriverPersonalData> _driverPersonalDataRepo;
    private readonly IRepository<CustomerPersonalData> _customerPersonalDataRepo;



    public DriverService(IServiceFactory serviceFactory)
    {
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
        _applicationUserRepo = _unitOfWork.GetRepository<ApplicationUser>();
        _driverPersonalDataRepo = _unitOfWork.GetRepository<DriverPersonalData>();
        _customerPersonalDataRepo = _unitOfWork.GetRepository<CustomerPersonalData>();

    }

    public async Task<DriverProfileResponse> GetDriverDetails(string userId)
    {
        ApplicationUser driver = await _applicationUserRepo.GetSingleByAsync(x => x.Id == userId,
                    include: x => x.Include(x => x.CarDetails)); 

        if (driver == null)
            throw new InvalidOperationException("invalid user id ");

        DriverProfileResponse response = new DriverProfileResponse
        {
            FullName = $"{driver.Firstname} {driver.Lastname}",
            EmailAddress = driver.Email!,
            Username = driver.UserName!,
            MobileNumber = driver.PhoneNumber!,
            CarDetails = new DriverCarDetailsResponse
            {
                DlNumber = driver.CarDetails?.DlNumber!,
                VehicleMake = driver.CarDetails?.VehicleMake!,
                CarModel = driver.CarDetails?.CarModel!,
                ProductionYear = driver.CarDetails?.ProductionYear!,
                CarColor = driver.CarDetails?.CarColor!,
                CarPlateNumber = driver.CarDetails?.CarPlateNumber!
            }
        };

        return response;
    }

}
