
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideConnect.Infrastructure.Interfaces;
using RideConnect.Models.Requests;
using RideConnect.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace RideConnect.API.Controllers;

[Route("api/[controller]")]
//[Authorize(Policy = "Authorization")]
[ApiController]
[SwaggerTag("Authentication operations")]

public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register-user", Name = "register-user")]
    //[SwaggerOperation(Summary = "Registers Customer")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "Successfully registered Customer", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Data", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> RegisterUser([FromBody] CustomerRegistrationRequest request)
    {
        string response = await _authenticationService.RegisterUser(request);
        return Ok(response);
    }

    [HttpGet("login", Name = "login-user")]
    //[SwaggerOperation(Summary = "Login User")]
    //[SwaggerResponse(StatusCodes.Status200OK, Description = "SuccessfulyLog in user", Type = typeof(SuccessResponse))]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Username and Password", Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}
