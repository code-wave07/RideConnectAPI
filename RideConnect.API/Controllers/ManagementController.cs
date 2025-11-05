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
[SwaggerTag("Management operations")]

public class ManagementController : BaseController
{
    private readonly IManagementService _managementService;

    public ManagementController(IManagementService managementService)
    {
        _managementService = managementService;
    }

    [AllowAnonymous]
    [HttpPost("add-or-update-ride-type", Name = "add-or-update-ride-type")]

    public async Task<IActionResult> AddOrUpdateRideType([FromBody] RideTypeRequest request)
    {
        string response = await _managementService.AddOrUpdateRideType(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("delete-ride-type", Name = "delete-ride-type")]

    public async Task<IActionResult> DeleteRideType(string rideTypeId)
    {
        string response = await _managementService.DeleteRideType(rideTypeId);
        return Ok(rideTypeId);
    }
}
