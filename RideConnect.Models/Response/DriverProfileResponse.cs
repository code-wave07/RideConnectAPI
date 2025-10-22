
using RideConnect.Models.Enums;

namespace RideConnect.Models.Response;

public class DriverProfileResponse
{
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    public UserType UserTypeId { get; set; }
    public string UserType{ get; set; }
   public DriverPersonalDataResponse DriverPersonalDataResponse { get; set; }
}


public class DriverPersonalDataResponse
{
    public string Id { get; set; }
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
