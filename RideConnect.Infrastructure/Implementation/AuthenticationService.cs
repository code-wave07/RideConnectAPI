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

namespace RideConnect.Infrastructure.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;

    public AuthenticationService(IServiceFactory serviceFactory, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _serviceFactory = serviceFactory;
        _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
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
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()?.Description}");

        return "User Created Successfully";
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
