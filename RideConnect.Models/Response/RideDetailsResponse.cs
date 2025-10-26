using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Models.Response;

public class RideDetailsResponse
{
    public string RideId { get; set; }
    public string From { get; set; }
    public string Location { get; set; }
    public string Price { get; set; }
    public string RideStatus { get; set; }
    public string RideType { get; set; }
    public string DriverName { get; set; }
    public string DriverId { get; set; }
    public string PassengerName { get; set; }
    public string PassengerId { get;set; }
}
