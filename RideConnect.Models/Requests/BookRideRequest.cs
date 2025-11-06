using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Models.Requests;

public class BookRideRequest
{
    public string From { get; set; } = "Akanu Ibiam International Airport";
    public string Location { get; set; }
    public string RideTypeId { get; set; }
    public string DriverId { get; set; }
    public string Price { get; set; }
}
