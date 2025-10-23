﻿using RideConnect.Models.Requests;

namespace RideConnect.Infrastructure.Interfaces;

public interface IManagementService
{
   public Task<string> AddOrUpdateRideType(RideTypeRequest request);
}
