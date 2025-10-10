using Microsoft.AspNetCore.Mvc;
using RideConnect.Models.Response;

namespace RideConnect.API.Controllers;

public class BaseController : ControllerBase
{
    public override OkObjectResult Ok(object value)
    {
        SuccessResponse response = new()
        {
            Success = true
        };

        if (value is string str)
        {
            response.Message = str;
        }
        else
        {
            response.Data = value;
        }

            return base.Ok(response);
    }
}
