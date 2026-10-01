using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILoginService _service;

    public AuthController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDto)
    {
        string? tokenString = await _service.LoginUser(loginRequestDto);

        if (tokenString is null) return NotFound("Invalid password or email!");

        return Ok( new { token = tokenString } );
    }
}