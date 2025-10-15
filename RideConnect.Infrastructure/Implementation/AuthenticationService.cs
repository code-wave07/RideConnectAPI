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

namespace RideConnect.Infrastructure.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;
    private readonly IRepository<DriverPersonalData> _driverPersonalDataRepo;
    private readonly IRepository<CustomerPersonalData> _customerPersonalDataRepo;



    public AuthenticationService(IServiceFactory serviceFactory, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
        _driverPersonalDataRepo = _unitOfWork.GetRepository<DriverPersonalData>();
        _customerPersonalDataRepo = _unitOfWork.GetRepository<CustomerPersonalData>();

    }

    public async Task<string> RegisterUser(CustomerRegistrationRequest request)
    {
        ApplicationUser existingUser = await _userManager.FindByNameAsync(request.PhoneNumber);

        if (existingUser != null)
            throw new InvalidOperationException("Username already exist");

        if (String.Equals(request.Password, request.ConfirmPassword) == false)
            throw new InvalidOperationException("Password and Confirm Password must match");

        ApplicationUser newUser = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.PhoneNumber,
            PhoneNumber = request.PhoneNumber,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            UserType = UserType.Customer
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()?.Description}");

        return $"{newUser.UserType} Created Successfully";
    }

    public async Task<string> RegisterDriver(DriverRegistrationRequest request)
    {
        ApplicationUser existingUser = await _userManager.FindByNameAsync(request.PhoneNumber);

        if (existingUser != null)
            throw new InvalidOperationException("Username already exist");

        if (String.Equals(request.Password, request.ConfirmPassword) == false)
            throw new InvalidOperationException("Password and Confirm Password must match");

        ApplicationUser newUser = new ApplicationUser
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            UserName = request.PhoneNumber,
            UserType = UserType.Driver
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()?.Description}");

        DriverPersonalData carDetails = new DriverPersonalData
        {
            UserId = newUser.Id,
            DlNumber = request.DlNumber,
            VehicleMake = request.VehicleMake,
            CarModel = request.CarModel,
            ProductionYear = request.ProductionYear,
            CarColor = request.CarColor,
            CarPlateNumber = request.CarPlateNumber
        };

        _driverPersonalDataRepo.Add(carDetails);
        await _unitOfWork.SaveChangesAsync();

        return $"{newUser.UserType} registered successfully.";
    }

    public static async Task<string> GetUserDetails (CustomerPersonalDataRequest request)
    {
        CustomerPersonalData customerPersonalData = new CustomerPersonalData
        {
            DateOfBirth = request.DateOfBirth,
            Address = request.Address,
        };

        return "User Details Added Successfully";
    }
}
