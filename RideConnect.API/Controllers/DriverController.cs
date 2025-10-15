
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using Swashbuckle.AspNetCore.Annotations;
using RideConnect.Infrastructure.Implementation;

namespace RideConnect.API.Controllers;

[Route("api/[controller]")]
//[Authorize(Policy = "Authorization")]
[ApiController]
[SwaggerTag("Authentication operations")]

public class DriverController : BaseController
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet("get-driver-profile", Name = "get-driver-profile")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> GetDriverProfile([FromQuery] string userId)
    {
        DriverProfileResponse response = await _driverService.GetDriverDetails(userId);
        return Ok(response);
    }
}
