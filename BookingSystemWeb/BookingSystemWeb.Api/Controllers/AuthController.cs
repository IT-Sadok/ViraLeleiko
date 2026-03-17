using BookingSystemWeb.Application.Interfaces;
using BookingSystemWeb.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        await _authService.RegisterAsync(request);
        return Ok("User registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.LoginAsync(request);
        return Ok(token);
    }
}