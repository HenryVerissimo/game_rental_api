using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IGameRepository
{
    Task<Game?> GetByIdAsync(int id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game> CreateAsync(Game game);
    Task<Game> UpdateAsync(Game currentGame, Game game);
    Task SoftDeleteAsync(Game game);
}