
namespace RideConnect.Models.Enums;

public enum UserType
{
    Driver = 1,
    Customer,
    Admin,
}

public static class UserTypeExtension
{
    public static string GetStringValue(this UserType studentModeOfEntry)
    {
        return studentModeOfEntry switch
        {
            UserType.Driver => "Driver",
            UserType.Customer => "Customer",
            UserType.Admin=> "Admin",
            _ => null
        };
    }
}
