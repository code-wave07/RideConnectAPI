using Microsoft.AspNetCore.Identity;
using RideConnect.Models.Enums;

namespace RideConnect.Models.Entities;

public class ApplicationUser : IdentityUser<string>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool Active { get; set; } = true;
    public UserType UserType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public virtual DriverPersonalData DriverPersonalData { get; set; }
}
