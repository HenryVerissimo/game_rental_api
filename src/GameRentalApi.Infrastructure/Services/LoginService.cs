using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace GameRentalApi.Infrastructure.Services;


public class LoginService : ILoginService
{
    private readonly IUserService _userService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IUserRoleService _userRoleService;
    private readonly ITokenService _tokenService;

    public LoginService(
        IUserService userService,
        IPasswordHasherService passwordHasherService,
        IUserRoleService userRoleService,
        ITokenService tokenService
    )
    {
        _userService = userService;
        _passwordHasherService = passwordHasherService;
        _userRoleService = userRoleService;
        _tokenService = tokenService;
    }

    public async Task<string?> LoginUser(LoginRequestDTO loginRequestDto)
    {
        User? user = await _userService.GetByEmailAsync(loginRequestDto.Email);

        if (user is null) return null;

        bool passwordIsValid = _passwordHasherService.ValidateHash(user, loginRequestDto.Password);

        if (passwordIsValid is false) return null;

        List<UserRole> userRoles = await _userRoleService.GetByUserIdAsync(user.Id);
        List<Role> roles = new();

        foreach (UserRole userRole in userRoles)
        {
            roles.Add(userRole.Role);
        }

        string tokenString = _tokenService.GenerateToken(user, roles);
        return tokenString;
    }
}