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
[SwaggerTag("Booking operations")]

public class RideManagementController : BaseController
{
    private readonly IRideManagementService _rideManagementService;

    public RideManagementController(IRideManagementService rideManagementService)
    {
        _rideManagementService = rideManagementService;
    }


    [HttpPost("book-ride", Name = "book-ride")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> BookRide([FromBody] BookRideRequest request)
    {
        string response = await _rideManagementService.BookRide(request);
        return Ok(response);
    }



    [HttpGet("get-ride/{id}", Name = "get-ride-details")]
    public async Task<IActionResult> GetRideDetails(string id)
    {
        RideDetailsResponse response = await _rideManagementService.GetRideDetails(id);
        return Ok(response);
    }

}
