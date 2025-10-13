
namespace RideConnect.Models.Entities;

public class CustomerPersonalData : BaseEntity
{
    public string Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
