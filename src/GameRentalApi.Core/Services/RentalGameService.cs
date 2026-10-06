using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class RentalGameService : IRentalGameService
{
    private readonly IRentalGameRepository _rentalGameRepository;
    private readonly IRentalRepository _rentalRepository;
    private readonly IGameRepository _gameRepository;

    public RentalGameService(IRentalGameRepository rentalGameRepository, IRentalRepository rentalRepository, IGameRepository gameRepository)
    {
        _rentalGameRepository = rentalGameRepository;
        _rentalRepository = rentalRepository;
        _gameRepository = gameRepository;
    }

    public async Task<RentalGame?> GetByFKsAsync(int gameId, int rentalId)
    {
        RentalGame? rentalGame = await _rentalGameRepository.GetByFKsAsync(gameId, rentalId);
        return rentalGame;
    }

    public async Task<List<RentalGame>> GetAllAsync()
    {
        IEnumerable<RentalGame> rentalGames = await _rentalGameRepository.GetAllAsync();
        return rentalGames.ToList();
    }

    public async Task<RentalGame?> CreateAsync(RentalGameRequestDTO rentalGameRequestDto)
    {

        Game? game = await _gameRepository.GetByIdAsync(rentalGameRequestDto.GameId);
        Rental? rental = await _rentalRepository.GetByIdAsync(rentalGameRequestDto.RentalId);

        if (game is null || rental is null) return null;

        RentalGame rentalGame = rentalGameRequestDto.ToRentalGame();
        RentalGame createdRentalGame = await _rentalGameRepository.CreateAsync(rentalGame);

        int gameQuantity = game.AvailableQuantity - rentalGameRequestDto.Quantity;

        if (gameQuantity < 0) return null;

        Game gameUpdated = new()
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Price = game.Price,
            ReleaseYear = game.ReleaseYear,
            UnitQuantity = game.UnitQuantity,
            AvailableQuantity = gameQuantity,
            GameCoverImageUrl = game.GameCoverImageUrl,
            UpdatedAt = DateTime.UtcNow,
            VideoGameId = game.VideoGameId

        };

        await _gameRepository.UpdateAsync(game, gameUpdated);
        return createdRentalGame;
    }

    public async Task<bool> UpdateAsync(int gameId, int rentalId, RentalGameRequestDTO rentalGameRequestDto)
    {
        RentalGame? currentRentalGame = await _rentalGameRepository.GetByFKsAsync(gameId, rentalId);

        if (currentRentalGame is null) return false;

        RentalGame updatedRentalGame = rentalGameRequestDto.ToRentalGame();
        updatedRentalGame.GameId = currentRentalGame.GameId;
        updatedRentalGame.RentalId = currentRentalGame.RentalId;

        await _rentalGameRepository.UpdateAsync(currentRentalGame, updatedRentalGame);
        return true;
    }

    public async Task<bool> DeleteAsync(int gameId, int rentalId)
    {
        RentalGame? rentalGame = await _rentalGameRepository.GetByFKsAsync(gameId, rentalId);

        if (rentalGame is null) return false;

        await _rentalGameRepository.DeleteAsync(rentalGame);
        return true;
    }
}