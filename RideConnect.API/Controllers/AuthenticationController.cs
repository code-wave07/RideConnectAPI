
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
[Authorize(Policy = "Authorization")]
[ApiController]
[SwaggerTag("Authentication operations")]

public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [HttpPost("register-user", Name = "register-user")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> RegisterUser([FromBody] CustomerRegistrationRequest request)
    {
        string response = await _authenticationService.RegisterUser(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register-driver", Name = "register-driver")]
    //[SwaggerOperation(Summary = "Login User")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "SuccessfullyLog in user", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Username and Password", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> RegisterDriver([FromBody] DriverRegistrationRequest request)
    {
        string response = await _authenticationService.RegisterDriver(request);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("login", Name = "login")]
    //[SwaggerOperation(Summary = "Login User")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "SuccessfullyLog in user", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Username and Password", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        LoginResponse response = await _authenticationService.Login(request);

        return Ok(response);
    }
}
