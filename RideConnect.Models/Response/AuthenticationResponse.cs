
using RideConnect.Models.Enums;
using RideConnect.Models.Requests;

namespace RideConnect.Models.Response;

public class LoginResponse{
    public JWTToken JwtToken { get; set; }
    public string RefreshToken { get; set; }
    public string Email { get; set; }
    public string Passport { get; set; }
    public string ProfilePicture { get; set; }
    public string UserType { get; set; }
    public UserType UserTypeId { get; set; }
    public string FullName { get; set; }
    public bool TwoFactor { get; set; }
    public string UserId { get; set; }
    public string Role { get; set; }
}
