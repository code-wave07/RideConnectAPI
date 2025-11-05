using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Models.Requests;

public class CancelRideRequest
{
    public string RideId { get; set; }
}

public class RejectRideRequest
{
    public string RideId { get; set; }
}

