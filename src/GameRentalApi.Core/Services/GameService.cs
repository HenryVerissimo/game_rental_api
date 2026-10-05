using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        Game? game = await _repository.GetByIdAsync(id);
        return game;
    }

    public async Task<List<Game>> GetAllAsync()
    {
        IEnumerable<Game> games = await _repository.GetAllAsync();
        return games.ToList();
    }

    public async Task<Game> CreateAsync(GameRequestDTO gameResponseDto)
    {
        Game game = gameResponseDto.ToGame();
        Game gameCreated = await _repository.CreateAsync(game);
        return gameCreated;
    }

    public async Task<bool> UpdateAsync(int id, GameRequestDTO gameRequestDto)
    {
        Game? currentGame = await _repository.GetByIdAsync(id);

        if (currentGame is null) return false;
        if (currentGame.DeletedAt != null) return false;

        Game updatedGame = gameRequestDto.ToGame();
        updatedGame.Id = currentGame.Id;

        await _repository.UpdateAsync(currentGame, updatedGame);
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        Game? game = await _repository.GetByIdAsync(id);

        if (game is null) return false;

        await _repository.SoftDeleteAsync(game);
        return true;
    }
}