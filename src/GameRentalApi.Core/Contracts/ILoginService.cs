using GameRentalApi.Core.DTOs;

namespace GameRentalApi.Core.Contracts;


public interface ILoginService
{
    Task<string?> LoginUser(LoginRequestDTO loginRequestDTO);
}