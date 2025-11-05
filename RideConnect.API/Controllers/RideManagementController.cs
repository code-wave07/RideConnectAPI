using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideConnect.Data.Implementation;
using RideConnect.Data.Interfaces;
using RideConnect.Infrastructure.Implementation;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Entities;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace RideConnect.API.Controllers;


[Route("api/[controller]")]
//[Authorize(Policy = "Authorization")]
[ApiController]
[SwaggerTag("Booking operations")]

public class RideManagementController : BaseController
{
    private readonly IRideManagementService _rideManagementService;
    private readonly IRepository<RideType> _rideTypeRepo;

    public RideManagementController(IRideManagementService rideManagementService, IUnitOfWork unitOfWork)
    {
        _rideManagementService = rideManagementService;
        _rideTypeRepo = unitOfWork.GetRepository<RideType>();
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


    [HttpGet("get-all-rides", Name = "get-all-rides")]
    public async Task<IActionResult> GetAllRides()
    {
        var response = await _rideManagementService.GetAllRides();
        return Ok(response);
    }

    
    [HttpPost("cancel-ride")]
    public async Task<IActionResult> CancelRide([FromBody] CancelRideRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.RideId))
            return BadRequest("Ride ID is required.");

        string response = await _rideManagementService.CancelRide(request.RideId);
        return Ok(new { message = response });
    }

   
    [HttpPost("reject-ride")]
    public async Task<IActionResult> RejectRide([FromBody] RejectRideRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.RideId))
            return BadRequest("Ride ID is required.");

        string response = await _rideManagementService.RejectRide(request.RideId);
        return Ok(new { message = response });
    }

    [HttpGet("ride-types")]
    public async Task<IActionResult> GetRideTypes()
    {
        var rideTypes = await _rideTypeRepo.GetAllAsync();
        return Ok(rideTypes);
    }

}
