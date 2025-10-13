
namespace RideConnect.Models.Response;

public class SuccessResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}

public class ErrorResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}
