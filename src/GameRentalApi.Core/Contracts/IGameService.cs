using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace  GameRentalApi.Core.Contracts;


public interface IGameService
{
    Task<Game?> GetByIdAsync(int id);
    Task<List<Game>> GetAllAsync();
    Task<Game> CreateAsync(GameRequestDTO gameRequestDto);
    Task<bool> UpdateAsync(int id, GameRequestDTO gameRequestDTO);
    Task<bool> SoftDeleteAsync(int id);
}