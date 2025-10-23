using RideConnect.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Infrastructure.Interfaces;

public interface IPassengerService
{
    public Task<string> BookRide(BookRideRequest request);
}
