using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using RideConnect.Models.Requests;

namespace RideConnect.Infrastructure.Interfaces;

public interface IAuthenticationService
{
    public Task<string> RegisterUser(CustomerRegistrationRequest request);
}
