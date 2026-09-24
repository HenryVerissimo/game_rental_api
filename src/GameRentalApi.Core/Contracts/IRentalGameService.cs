using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRentalGameService
{
    Task<RentalGame?> GetByFKsAsync(int gameId, int rentalId);
    Task<List<RentalGame>> GetAllAsync();
    Task<RentalGame> CreateAsync(RentalGameRequestDTO rentalGameRequestDto);
    Task<bool> UpdateAsync(int gameId, int rentalId, RentalGameRequestDTO rentalGameRequestDto);
    Task<bool> DeleteAsync(int gameId, int rentalId);
}