using RideConnect.Models.Enums;

namespace RideConnect.Models.Response;


public class RideDetailsResponse
{
    public string RideId { get; set; }
    public string From { get; set; }
    public string Location { get; set; }
    public string Price { get; set; }
    public string RideStatus { get; set; }
    public RideStatus RideStatusId { get; set; }
    public RideTypeResponse RideType { get; set; }
    public DriverDataResponse Driver { get; set; }
    public CustomerDataResponse Customer { get; set; }
}

public class DriverDataResponse
{
    public string Fullname { get; set; }
    public string DriverId { get; set; }
}

public class CustomerDataResponse
{
    public string Fullname { get; set; }
    public string CustomerId { get; set; }
}

public class RideTypeResponse
{
    public string Name { get; set; }
    public string RideTypeId { get; set; }
}