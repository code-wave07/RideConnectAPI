using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Enums;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace RideConnect.API.Controllers;

[Route("api/[controller]")]
[Authorize(Policy = "Authorization")]
[ApiController]
[SwaggerTag("Authentication operations")]

public class ManagementController : BaseController
{
    private readonly IManagementService _managementService;

    public ManagementController(IManagementService managementService)
    {
        _managementService = managementService;
    }

    [AllowAnonymous]
    [HttpPost("ride-type", Name = "ride-type")]

    public async Task<IActionResult> CreateRideType([FromBody] string rideType)
    {
        string response = await _managementService.CreateRideType(rideType);
        return Ok(response);
    }
}
