using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface ITokenService
{
    string GenerateToken(User user, List<Role> roles);
}