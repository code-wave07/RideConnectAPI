using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;

namespace RideConnect.Infrastructure.Interfaces;

public interface IAuthenticationService
{
    public Task<string> RegisterUser(CustomerRegistrationRequest request);
    public Task<string> RegisterDriver(DriverRegistrationRequest request);
    public Task<LoginResponse> Login(LoginRequest request);
}
