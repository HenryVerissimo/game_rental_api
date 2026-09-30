using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace GameRentalApi.Infrastructure.Services;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<User> _hasher = new();

    public string CreateHash(User user, string password)
    {
        return _hasher.HashPassword(user, password);
    }

    public bool ValidateHash(User user, string password)
    {
        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        
        if (result is PasswordVerificationResult.Success) return true;

        return false;
    }
}