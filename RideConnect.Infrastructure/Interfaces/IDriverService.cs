using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;

namespace RideConnect.Infrastructure.Interfaces;

public interface IDriverService
{
    public Task<DriverProfileResponse> GetDriverDetails(string userId);
}
