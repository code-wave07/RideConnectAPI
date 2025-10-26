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

public class PassengerController : BaseController
{
    private readonly IPassengerService _passengerService;

    public PassengerController(IPassengerService passengerService)
    {
        _passengerService = passengerService;
    }

    [Authorize]
    [HttpPost("book-ride", Name = "book-ride")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> BookRide([FromBody] BookRideRequest request)
    {
        string response = await _passengerService.BookRide(request);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("get-driver", Name = "get-driver")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> GetDriverProfile(string id)
    {
        DriverProfileResponse response = await _passengerService.GetDriver(id);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("get-ride/{id}", Name = "get-ride-details")]
    public async Task<IActionResult> GetRideDetails(string id)
    {
        RideDetailsResponse response = await _passengerService.GetRideDetails(id);
        return Ok(response);
    }

}
