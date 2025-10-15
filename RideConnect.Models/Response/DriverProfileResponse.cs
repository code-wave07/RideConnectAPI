
namespace RideConnect.Models.Response;

public class DriverProfileResponse
{
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    public DriverCarDetailsResponse CarDetails { get; set; }
}

public class DriverCarDetailsResponse
{
    public string DlNumber { get; set; }
    public string VehicleMake { get; set; }
    public string CarModel { get; set; }
    public string ProductionYear { get; set; }
    public string CarColor { get; set; }
    public string CarPlateNumber { get; set; }
}
