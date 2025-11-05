namespace RideConnect.Models.Entities;

public class CarDetails : BaseEntity
{
    public string Id { get; set; }
    public string? NumberOfSeats { get; set; }
    public string DlNumber { get; set; }
    public string VehicleMake { get; set; }
    public string CarModel { get; set; }
    public string ProductionYear { get; set; }
    public string CarColor { get; set; }
    public string CarPlateNumber { get; set; }
    public string UserId { get; set; }
    public virtual DriverPersonalData User { get; set; }
}
