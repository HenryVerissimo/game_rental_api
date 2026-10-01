using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILoginService _loginService;
    private readonly IUserService _userService;

    public AuthController(ILoginService service, IUserService userService)
    {
        _loginService = service;
        _userService = userService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDto)
    {
        string? tokenString = await _loginService.LoginUser(loginRequestDto);

        if (tokenString is null) return NotFound("Invalid password or email!");

        return Ok( new { token = tokenString } );
    }

    [HttpPost("create-account")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccountAsync(UserRequestDTO userRequestDto)
    {
        var user = await _userService.CreateAsync(userRequestDto);
        return Ok("Account created with success!");
    }
}